using GordonEssentials;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagementInterface : Singleton<ManagementInterface>
{
    [SerializeField] TMP_Text money;
    [SerializeField] Button returnBtn;

    private void Start()
    {
        money.text = SavableDataManager.Instance.data.money.ToString();
        returnBtn.onClick.AddListener(ReturnBehaviour);
    }

    private void ReturnBehaviour()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.ChooseMapScene);
    }
}
