using GordonEssentials;
using UnityEngine;
using UnityEngine.UI;

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
