using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PopupWindowPanel : MonoBehaviour
{
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

    public void ChooseModal(List<IDisplayable> elements, Action<IDisplayable> OnItemChoose, string title = null, string content = null, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show(title, horizontal: false);
        verticalLayoutText.text = content;
        FillChoices(elements);

        confirmAction += () =>
        {
            if (choiceItem != null)
            {
                OnItemChoose?.Invoke(choiceItem);
            }
            Close();
        };

        declineAction += () =>
        {
            Close();
        };

        SetupButtons(confirmAction, declineAction, alternateAction);
    }

    public void ShowAsEvent(string title, Sprite image, string massage, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show(title, horizontal: true);
        horizontalLayoutText.text = massage;
        horizontalLayoutImage.sprite = image;

        confirmAction += () =>
        {
            Close();
        };

        declineAction += () =>
        {
            Close();
        };

        SetupButtons(confirmAction, declineAction, alternateAction);
    }


    private void FillChoices(List<IDisplayable> elements)
    {
        ChoiceUI.OnChoiceSelected += SetChoice;
        for (int i = 0; i < elements.Count; i++)
        {
            var choice = Instantiate(choiceUIPrefab, choices);
            listOfChoices.Add(choice);
            choice.Init(elements[i]);
        }
    }

    private void SetupButtons(Action confirmAction, Action declineAction, Action alternateAction)
    {
        InitializeButton(confirmButton, "Confirm", confirmAction);
        InitializeButton(alternateButton, "Alternate", alternateAction);
        InitializeButton(declineButton, "Decline", declineAction);
    }

    private void InitializeButton(PopupButton button, string label, Action action)
    {
        if (action != null)
        {
            button.Init(label, action.Invoke);
        }
    }

    private void Show(string title, bool horizontal)
    {
        horizontalLayoutArea.gameObject.SetActive(horizontal);
        verticalLayoutArea.gameObject.SetActive(!horizontal);

        headerArea.gameObject.SetActive(string.IsNullOrEmpty(title));
        headerText.text = title;

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
