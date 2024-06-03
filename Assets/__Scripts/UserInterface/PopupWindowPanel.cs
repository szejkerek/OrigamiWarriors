using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PopupWindowPanel : MonoBehaviour
{
    public static Action<IDisplayable> OnItemChoose;
    public readonly int PopupShowHash = Animator.StringToHash("PopupShow");
    public readonly int PopupCloseHash = Animator.StringToHash("PopupClose");

    [Header("Header")]
    [SerializeField] private Transform headerArea;
    [SerializeField] private TextMeshProUGUI headerText;

    [Header("Content")]
    [SerializeField] private Transform contentArea;
    [SerializeField] private Transform verticalLayoutArea;
    [SerializeField] private Transform choices;
    [SerializeField] private List<ChoiceUI> listOfChoices;
    [SerializeField] private TextMeshProUGUI verticalLayoutText;
    [SerializeField] private ChoiceUI choiceUIPrefab;
    [Space]
    [SerializeField] private Transform horizontalLayoutArea;
    [SerializeField] private Transform horizontalLayoutImageContainer;
    [SerializeField] private Image horizontalLayoutImage;
    [SerializeField] private TextMeshProUGUI horizontalLayoutText;

    [Header("Footer")]
    [SerializeField] private Transform footerArea;
    [SerializeField] private PopupButton confirmButton;
    [SerializeField] private PopupButton declineButton;
    [SerializeField] private PopupButton alternateButton;
    [SerializeField] private Animator animator;

    IDisplayable choiceItem;

    public void ChooseModal(List<IDisplayable> elements, string title = null, string content = null, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show(horizontal: false);

        headerArea.gameObject.SetActive(!string.IsNullOrEmpty(title));
        headerText.text = title;

        ChoiceUI.OnChoiceSelected += SetChoice;
        for (int i = 0; i < elements.Count; i++)
        {
            var choice = Instantiate(choiceUIPrefab, choices);
            listOfChoices.Add(choice);
            choice.Init(elements[i]);
        }

        verticalLayoutText.text = content;

        confirmButton.Init("Confirm", () => { 
            confirmAction?.Invoke(); 
            if(choiceItem != null)
            {
                OnItemChoose?.Invoke(choiceItem); 
            }
            Close(); 
        });

        declineButton.Init("Decline", () => { 
            declineAction?.Invoke(); 
            Close(); 
        });

        alternateButton.Init("Alternate", () => { 
            alternateAction?.Invoke();
        });
    }

    public void ShowAsEvent(string title, Sprite image, string massage, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show(horizontal: true);
        headerArea.gameObject.SetActive(string.IsNullOrEmpty(title));
        headerText.text = title;

        horizontalLayoutImage.sprite = image;
        horizontalLayoutText.text = massage;

        confirmButton.Init("Confirm", () => {
            confirmAction?.Invoke();
            if (choiceItem != null)
            {
                OnItemChoose?.Invoke(choiceItem);
            }
            Close();
        });

        declineButton.Init("Decline", () => {
            declineAction?.Invoke();
            Close();
        });

        alternateButton.Init("Alternate", () => {
            alternateAction?.Invoke();
        });
    }



    private void Show(bool horizontal)
    {
        horizontalLayoutArea.gameObject.SetActive(horizontal);
        verticalLayoutArea.gameObject.SetActive(!horizontal);

        if (animator != null)
        {
            gameObject.SetActive(true);
            animator.Play(PopupShowHash);
        }
    }

    private void Close()
    {      
        ChoiceUI.OnChoiceSelected -= SetChoice;

        if (animator != null)
        {
            animator.Play(PopupCloseHash);
            StartCoroutine(DeactivateAfterAnimation(animator.GetCurrentAnimatorStateInfo(0).length));
        }
        
    }
    private IEnumerator DeactivateAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);

        foreach (var item in listOfChoices)
        {
            Destroy(item.gameObject);
        }
        listOfChoices.Clear();
    }

    private void SetChoice(IDisplayable choice)
    {
        choiceItem = choice;
    }
}
