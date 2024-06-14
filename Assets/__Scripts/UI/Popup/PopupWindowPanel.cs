using DG.Tweening;
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
    [SerializeField] private Transform choicesParent;
    [SerializeField] private ChoiceUI choiceUIPrefab;
    
    [Header("Header")]
    [SerializeField] private Transform headerArea;
    [SerializeField] private TextMeshProUGUI headerText;

    [Header("Content")]
    [SerializeField] private Transform verticalLayoutArea;
    [SerializeField] private TextMeshProUGUI verticalLayoutText;
    [Space]
    [SerializeField] private Transform horizontalLayoutArea;
    [SerializeField] private Image horizontalLayoutImage;
    [SerializeField] private TextMeshProUGUI horizontalLayoutText;

    [Header("Footer")]
    [SerializeField] private PopupButton confirmButton;
    [SerializeField] private PopupButton declineButton;
    [SerializeField] private PopupButton alternateButton;

    CanvasGroup canvasGroup;
    IDisplayable choiceItem;
    List<ChoiceUI> listOfChoices;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        Deinit();
        Close();    
    }

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

    public void ShowAsEvent(PopupEventSO eventData, Action confirmAction = null, Action declineAction = null, Action alternateAction = null)
    {
        Show(eventData.Header, horizontal: true);
        horizontalLayoutText.text = eventData.Content;
        horizontalLayoutImage.sprite = eventData.DisplayImage;

        confirmAction += () =>
        {
            eventData.OnAccept.Apply();
            Close();
        };

        declineAction += () =>
        {
            eventData.OnDecline.Apply();
            Close();
        };

        SetupButtons(confirmAction, declineAction, alternateAction);
    }


    private void FillChoices(List<IDisplayable> elements)
    {
        ChoiceUI.OnChoiceSelected += SetChoice;
        for (int i = 0; i < elements.Count; i++)
        {
            var choice = Instantiate(choiceUIPrefab, choicesParent);
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


        headerArea.gameObject.SetActive(title != "");
        headerText.text = title;


        gameObject.SetActive(true);
        DOTween.Sequence()
        .Append(canvasGroup.DOFade(1, 0.75f))
        .Join(transform.DOScale(Vector3.one, 0.75f).SetEase(Ease.OutBounce))
        .Play();
    }

    private void Close()
    {      
        ChoiceUI.OnChoiceSelected -= SetChoice;

        DOTween.Sequence()
        .Append(canvasGroup.DOFade(0, 0.5f))
        .Join(transform.DOScale(Vector3.zero, 0.5f))
        .OnComplete(Deinit)
        .Play();
    }

    private void Deinit()
    {
        gameObject.SetActive(false);

        if(listOfChoices != null)
        {
            foreach (var item in listOfChoices)
            {
                Destroy(item.gameObject);
            }
            listOfChoices.Clear();
            listOfChoices = null;
        }
    }

    private void SetChoice(IDisplayable choice)
    {
        choiceItem = choice;
    }
}
