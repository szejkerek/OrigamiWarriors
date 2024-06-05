using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
//
public class ChoiceUI : MonoBehaviour
{
    public static Action<IDisplayable> OnChoiceSelected;
    [SerializeField] Button choiceBtn;
    [SerializeField] GameObject selectedBorder;
    [SerializeField] Image image;

    IDisplayable choiceItem;

    public void Init(IDisplayable choiceItem)
    {
        selectedBorder.SetActive(false);
        this.choiceItem = choiceItem;
        new AssetReference(choiceItem.DisplayIconGuid).LoadAssetAsync<Sprite>().Completed += handle => { image.sprite = handle.Result; };
        choiceBtn.onClick.AddListener(SelectChoice);
        OnChoiceSelected += DisableBorder;
    }

    public void EnableBorder()
    {
        selectedBorder.SetActive(true);
    }

    void DisableBorder(IDisplayable _)
    {
        selectedBorder.SetActive(false);
    }

    private void SelectChoice()
    {
        OnChoiceSelected?.Invoke(choiceItem);
        selectedBorder.SetActive(true);
    }

    private void OnDisable()
    {
        image.sprite = null;
        OnChoiceSelected -= DisableBorder;
    }

}
