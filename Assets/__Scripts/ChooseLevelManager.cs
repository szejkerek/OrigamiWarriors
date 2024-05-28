using GordonEssentials;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] Button teamManagementBtn;
    [SerializeField] Button returnBtn;
    [SerializeField] Button infoBtn;
    private void Awake()
    {
        teamManagementBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ManagementScene));
        returnBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.MenuScene));
        infoBtn.onClick.AddListener(InfoDisplay);
    }

    private void InfoDisplay()
    {
        Debug.Log("POPUP");
    }
}
