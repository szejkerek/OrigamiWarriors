using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class BounceText : MonoBehaviour
{
  [Header("Object references")]
  [SerializeField] private Image img;
  [SerializeField] private TextMeshProUGUI text;

  [Header("Image params")]
  [SerializeField] private float imgXScale = 1.1f;
  //[SerializeField] private float imgYScale = .99f;
  [SerializeField] private float imgScaleTime = 1f;

  [Header("Text params")]
  [SerializeField] private float textFadeAlpha = .5f;
  [SerializeField] private float textFadeTime = 1f;

  private void Start()
  {
    //SetUpdate(true) will update using unscaled time
    img.transform.DOScaleX(imgXScale, imgScaleTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(true);
    //img.transform.DOScaleY(imgYScale, imgScaleTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(true);
    text.DOFade(textFadeAlpha, textFadeTime).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine).SetUpdate(true);
  }
}
