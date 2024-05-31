using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PopupWindowPanel : MonoBehaviour
{
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
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button declineButton;
    [SerializeField] private Button alternateButton;
    [SerializeField] private Animator animator;

    private Action<int> onConfirmAction;
    private Action onDeclineAction;
    private Action onAlternateAction;
    int choiceIndex;

    public void Confirm()
    {
        ChoiceUI.OnChoiceSelected -= SetChoice;
        onConfirmAction?.Invoke(choiceIndex);
        Close();
    }
    public void Decline()
    {
        onDeclineAction?.Invoke();
        Close();
    }
    public void Alternate()
    {
        onAlternateAction?.Invoke();
        Close();
    }

    public void ShowAsCharacterChoose(string title, List<IDisplayable> elements, string massage, Action<int> confirmAction, Action declineAction, Action alternateAction)
    {
        Show();
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

        bool hasTitle = !string.IsNullOrEmpty(title);
        headerArea.gameObject.SetActive(hasTitle);
        headerText.text = title;

        int i =0;
        ChoiceUI.OnChoiceSelected += SetChoice;
        foreach (var element in elements) 
        { 
            ChoiceUI ob = Instantiate(choiceUIPrefab, choices);
            listOfChoices.Add(ob);
            ob.choice = i++;
            new AssetReference(element.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { ob.image.sprite = handle.Result; };
        }


        verticalLayoutText.text = massage;
        onConfirmAction = confirmAction;

        bool hasDecline= declineAction != null;
        declineButton.gameObject.SetActive(hasDecline);
        onDeclineAction = declineAction;

        bool hasAlternate = alternateAction != null;
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
    }

    public void ShowAsEvent(string title, IDisplayable element1, string massage, Action<int> confirmAction, Action declineAction, Action alternateAction)
    {
        Show();
        horizontalLayoutArea.gameObject.SetActive(true);
        verticalLayoutArea.gameObject.SetActive(false);

        bool hasTitle = string.IsNullOrEmpty(title);
        headerArea.gameObject.SetActive(hasTitle);
        headerText.text = title;
        new AssetReference(element1.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { horizontalLayoutImage.sprite = handle.Result; };
        horizontalLayoutText.text = massage;

        onConfirmAction = confirmAction;
        onDeclineAction = declineAction;

        bool hasAlternate = alternateAction != null;
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
    }



    private void Show()
    {
        if (animator != null)
        {
            gameObject.SetActive(true);
            animator.Play("PopupShow"); // Nazwa animacji otwierania
        }
    }

    private void Close()
    {
        foreach (var item in listOfChoices)
        {
            Destroy(item.gameObject);
        }
        listOfChoices.Clear();


        if (animator != null)
        {
            animator.Play("PopupClose"); // Nazwa animacji zamykania
            StartCoroutine(DeactivateAfterAnimation(animator.GetCurrentAnimatorStateInfo(0).length));
        }
        
    }
    private IEnumerator DeactivateAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void SetChoice(int choice)
    {
        choiceIndex = choice;
    }
}
