using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LoreAnimation : MonoBehaviour
{
  [SerializeField] private Image lorePart1Img;
  [SerializeField] private TextMeshProUGUI lorePart1Text;

  [SerializeField] private Image lorePart2Img;
  [SerializeField] private TextMeshProUGUI lorePart2Text;

  [SerializeField] private Image lorePart3Img;
  [SerializeField] private TextMeshProUGUI lorePart3Text;

  public float startupDelay = 1f;
  public float imageAnimationTime = .5f;
  public float textAnimationTime = 1f;
  public float segmentDelay = 2f;


  // Start is called before the first frame update
  private void Awake()
  {
    
    DOTween.Sequence()
      .Append(lorePart1Img.DOFade(1f, imageAnimationTime))
      .Join(lorePart1Text.DOFade(1f, textAnimationTime))
      .Append(lorePart1Img.DOFade(1f, segmentDelay))
      .Append(lorePart2Img.DOFade(1f, imageAnimationTime))
      .Join(lorePart2Text.DOFade(1f, textAnimationTime))
      .Append(lorePart1Img.DOFade(1f, segmentDelay))
      .Append(lorePart3Img.DOFade(1f, imageAnimationTime))
      .Join(lorePart3Text.DOFade(1f, textAnimationTime))
      .SetDelay(startupDelay)
      .Play();
  }
}
