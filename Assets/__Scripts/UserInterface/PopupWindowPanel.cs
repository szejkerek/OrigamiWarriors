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
    [SerializeField] private Image verticalLayoutImage1;
    [SerializeField] private Image verticalLayoutImage2;
    [SerializeField] private Image verticalLayoutImage3;
    [SerializeField] private TextMeshProUGUI verticalLayoutText;
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

    private Action onConfirmAction;
    private Action onDeclineAction;
    private Action onAlternateAction;


    public void Confirm()
    {
        onConfirmAction?.Invoke();
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

    public void ShowAsCharacterChoose(string title, IDisplayable element1, IDisplayable element2, IDisplayable element3, string massage, Action confirmAction, Action declineAction, Action alternateAction)
    {
        Show();
        horizontalLayoutArea.gameObject.SetActive(false);
        verticalLayoutArea.gameObject.SetActive(true);

        bool hasTitle = string.IsNullOrEmpty(title);
        headerArea.gameObject.SetActive(hasTitle);
        headerText.text = title;
        new AssetReference(element1.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { verticalLayoutImage1.sprite = handle.Result; };
        new AssetReference(element2.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { verticalLayoutImage2.sprite = handle.Result; };
        new AssetReference(element3.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { verticalLayoutImage3.sprite = handle.Result; };
        verticalLayoutText.text = massage;

        onConfirmAction = confirmAction;
        onDeclineAction = declineAction;

        bool hasAlternate = alternateAction != null;
        alternateButton.gameObject.SetActive(hasAlternate);
        onAlternateAction = alternateAction;
    }

    public void ShowAsEvent(string title, IDisplayable element1, string massage, Action confirmAction, Action declineAction, Action alternateAction)
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
}
