using GordonEssentials;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInterface : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button quitBtn;

    private void Awake()
    {
        startBtn.onClick.AddListener(StartGame);
        quitBtn.onClick.AddListener(() => Application.Quit());
    }

    private void StartGame()
    {
        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }
}
