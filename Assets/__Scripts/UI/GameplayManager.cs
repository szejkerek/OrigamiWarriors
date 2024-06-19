using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public LevelResults LevelResults = new LevelResults();
    private void Awake()
    {
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
