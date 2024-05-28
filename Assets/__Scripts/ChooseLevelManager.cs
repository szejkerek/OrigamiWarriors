using GordonEssentials;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] Button teamManagementBtn;
    private void Awake()
    {
        teamManagementBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ManagementScene));
    }
}
