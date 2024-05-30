using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public TMP_Text header;
    public TMP_Text content;
    public LayoutElement layoutElement;
    public int characterWrapLimit;

    public void SetText(string content, string header = "")
    {
        this.header.text = header;
        this.header.gameObject.SetActive(!string.IsNullOrEmpty(header));

        this.content.text = content;



        Resize();
    }

    private void Resize()
    {
        int headerLenght = header.text.Length;
        int contentLenght = content.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit); 
    }
}
