using GordonEssentials;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LevelResults
{
    public bool isWin;
    public int money;
    public int exp;
    public List<Character> deadCharacters = new List<Character>();
}

public class GameplayUI : MonoBehaviour
{
    [SerializeField] Button winBtn;
    [SerializeField] Button loseBtn;

    public LevelResults LevelResults = new LevelResults(); 

    private void Awake()
    {
        winBtn.onClick.AddListener(() => LevelCompleted(true));
        loseBtn.onClick.AddListener(() => LevelCompleted(false));

        LevelResults.money = 69;
    }
    public void LevelCompleted(bool isWin)
    {
        LevelResults.isWin = isWin;
        SavableDataManager.Instance.data.levelResults = LevelResults;
        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }
}
