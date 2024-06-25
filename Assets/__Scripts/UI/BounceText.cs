using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class BounceText : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject parent;
    private void Start()
    {
    parent.transform.DOScaleX(1.15f, 1f).SetLoops(1, LoopType.Yoyo).Play();
    //textMeshPro.DOFade(1f, 1f).SetLoops(1, LoopType.Yoyo);
    //textMeshPro.DOFade(0,1);
  }
}
