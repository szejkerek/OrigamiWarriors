using GordonEssentials;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LevelResults
{
    public bool isWin;
    public int colectedMoney;
    public int collectedExp;

    public int expOnWin;
    public int moneyOnWin;
    //Penalty for lose
    public int moneyOnLose;

    public List<Character> deadCharacters = new List<Character>();

    public void Apply()
    {
        SavableDataManager.Instance.data.playerResources.AddMoney(CalculateMoney());
        SavableDataManager.Instance.data.playerResources.AddExpirience(CalculateExp());

        foreach (Character character in deadCharacters)
        {
            SavableDataManager.Instance.data.team.KillCharacter(character);
        }

        ClearData();
    }

    private int CalculateExp()
    {
        if(isWin)
        {
            return expOnWin + collectedExp;
        }
        return collectedExp;
    }

    private int CalculateMoney()
    {
        if (isWin)
        {
            return moneyOnWin + colectedMoney;
        }
        return colectedMoney + moneyOnLose;
    }

    private void ClearData()
    {
        isWin = false;
        colectedMoney = 0;
        collectedExp = 0;
        expOnWin = 0;
        moneyOnWin = 0;
        moneyOnLose = 0;
        deadCharacters.Clear();
    }
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

        LevelResults.colectedMoney = 69;
    }
    public void LevelCompleted(bool isWin)
    {
        LevelResults.isWin = isWin;
        SavableDataManager.Instance.data.levelResults = LevelResults;
        LevelResults.Apply();

        SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene);
    }
}
