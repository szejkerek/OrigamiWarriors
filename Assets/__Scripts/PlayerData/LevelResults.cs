using System;
using System.Collections.Generic;

[Serializable]
public class LevelResults
{
    public bool isWin;
    public int colectedMoney;

    public int moneyOnWin;
    public int moneyOnLose;

    public List<Character> deadCharacters = new List<Character>();

    public void Apply()
    {
        SavableDataManager.Instance.data.playerResources.AddMoney(CalculateMoney());

        foreach (Character character in deadCharacters)
        {
            SavableDataManager.Instance.data.team.KillCharacter(character);
        }

        ClearData();
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
        moneyOnWin = 0;
        moneyOnLose = 0;
        deadCharacters.Clear();
    }
}
