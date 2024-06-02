using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PopupButton :MonoBehaviour
{
    Button button;
    TMP_Text buttonText;

    Action customAction;
    Action closeAction;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<TMP_Text>();
        button.gameObject.SetActive(false);
    }

    public void Init(string text, Action action, Action close)
    {
        customAction = action;
        closeAction = close;
        buttonText.text = text; 
        button.gameObject.SetActive(true);
        button.onClick.AddListener(TriggerAction);
    }

    public void Deinit()
    {
        button.gameObject.SetActive(false);
        buttonText.text = string.Empty;
        button.onClick.RemoveListener(TriggerAction);
    }

    void TriggerAction()
    {
        customAction?.Invoke();
        closeAction?.Invoke();
    }
}
