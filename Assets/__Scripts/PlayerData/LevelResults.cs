using System;
using System.Collections.Generic;

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
    public List<Character> newCharacters = new List<Character>();

    public void Apply()
    {
        SavableDataManager.Instance.data.playerResources.AddMoney(CalculateMoney());
        SavableDataManager.Instance.data.playerResources.AddExpirience(CalculateExp());

        foreach (Character character in deadCharacters)
        {
            SavableDataManager.Instance.data.team.KillCharacter(character);
        }
        foreach (Character character in newCharacters)
        {
            SavableDataManager.Instance.data.team.AddCharacter(character);
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
        newCharacters.Clear();
    }
}
