using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LoreAnimation : MonoBehaviour
{
  [SerializeField] private GameObject lorePart1;
  [SerializeField] private Image lorePart1Img;
  [SerializeField] private TextMeshProUGUI lorePart1Text;

  [SerializeField] private GameObject lorePart2;
  [SerializeField] private Image lorePart2Img;
  [SerializeField] private TextMeshProUGUI lorePart2Text;

  [SerializeField] private GameObject lorePart3;
  [SerializeField] private Image lorePart3Img;
  [SerializeField] private TextMeshProUGUI lorePart3Text;


  // Start is called before the first frame update
  private void Awake()
  {
    lorePart1.SetActive(true);
    DOTween.Sequence()
      .Append(lorePart1Img.DOFade(1f, 5f))
      .Play();
  }
}
