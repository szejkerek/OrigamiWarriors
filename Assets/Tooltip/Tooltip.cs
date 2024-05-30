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

    RectTransform _rectTransform;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

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

    private void LateUpdate()
    {
        var position = Input.mousePosition;
        var normalizedPosition = new Vector2(position.x / Screen.width, position.y / Screen.height);
        var pivot = CalculatePivot(normalizedPosition);
        _rectTransform.pivot = pivot;
        transform.position = position;
    }

    private Vector2 CalculatePivot(Vector2 normalizedPosition)
    {
        var pivotTopLeft = new Vector2(-0.05f, 1.05f);
        var pivotTopRight = new Vector2(1.05f, 1.05f);
        var pivotBottomLeft = new Vector2(-0.05f, -0.05f);
        var pivotBottomRight = new Vector2(1.05f, -0.05f);

        if (normalizedPosition.x < 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopLeft;
        }
        else if (normalizedPosition.x > 0.5f && normalizedPosition.y >= 0.5f)
        {
            return pivotTopRight;
        }
        else if (normalizedPosition.x <= 0.5f && normalizedPosition.y < 0.5f)
        {
            return pivotBottomLeft;
        }
        else
        {
            return pivotBottomRight;
        }
    }


}
