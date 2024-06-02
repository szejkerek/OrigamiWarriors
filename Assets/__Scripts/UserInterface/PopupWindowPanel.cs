using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
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

    //public void Confirm()
    //{
    //    ChoiceUI.OnChoiceSelected -= SetChoice;
    //    onConfirmAction?.Invoke();
    //    Close();
    //}
    //public void Decline()
    //{
    //    onDeclineAction?.Invoke();
    //    Close();
    //}
    //public void Alternate()
    //{
    //    onAlternateAction?.Invoke();
    //    Close();
    //}

    public void ShowAsCharacterChoose(List<IDisplayable> elements, string title = null, string content = null, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show();
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

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

        confirmButton.Init("Confirm", confirmAction, Close);
        declineButton.Init("Decline", declineAction, Close);
        alternateButton.Init("Alternate", alternateAction, Close);
    }

    //public void ShowAsEvent(string title, IDisplayable element1, string massage, Action<int> confirmAction, Action declineAction, Action alternateAction)
    //{
    //    Show();
    //    horizontalLayoutArea.gameObject.SetActive(true);
    //    verticalLayoutArea.gameObject.SetActive(false);

    //    bool hasTitle = string.IsNullOrEmpty(title);
    //    headerArea.gameObject.SetActive(hasTitle);
    //    headerText.text = title;
    //    new AssetReference(element1.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { horizontalLayoutImage.sprite = handle.Result; };
    //    horizontalLayoutText.text = massage;

    //    onConfirmAction = confirmAction;
    //    onDeclineAction = declineAction;

    //    bool hasAlternate = alternateAction != null;
    //    alternateButton.gameObject.SetActive(hasAlternate);
    //    onAlternateAction = alternateAction;
    //}



    private void Show()
    {
        if (animator != null)
        {
            gameObject.SetActive(true);
            animator.Play(PopupShowHash);
        }
    }

    private void Close()
    {
        OnItemChoose?.Invoke(choiceItem);

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
