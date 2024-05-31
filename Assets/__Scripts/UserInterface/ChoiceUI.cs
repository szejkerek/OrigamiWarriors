using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour
{
    public static Action<int> OnChoiceSelected;
    [SerializeField] Button choiceBtn;
    [SerializeField] GameObject selectedBorder;
    [SerializeField] public Image image;
    [SerializeField] public int choice;



    private void OnEnable()
    {
        selectedBorder.SetActive(false);
        choiceBtn.onClick.AddListener(SelectChoice);
        OnChoiceSelected += DisableBorder;
    }
    public void EnableBorder()
    {
        selectedBorder.SetActive(true);
    }

    void DisableBorder(int _)
    {
        selectedBorder.SetActive(false);
    }

    private void OnDisable()
    {
        OnChoiceSelected -= DisableBorder;
    }


    private void SelectChoice()
    {
        OnChoiceSelected?.Invoke(choice);
        selectedBorder.SetActive(true);
    }

}
