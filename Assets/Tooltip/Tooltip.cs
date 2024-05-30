using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TMP_Text header;
    public TMP_Text content;
    public LayoutElement layoutElement;
    public int characterWrapLimit;

    private void Update()
    {
        int headerLenght = header.text.Length;
        int contentLenght = content.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit); 
    }
}
