using UnityEngine;
using UnityEngine.UI;

public class LoreInterface : MonoBehaviour
{
    [SerializeField] Button startBtn = null;
    //[SerializeField] Button skipBtn = null;
    [SerializeField] Button quitBtn = null;

    [SerializeField] Sound buttonPressed = null;
    [SerializeField] Sound buttonHover = null;

    private void Awake()
    {
    startBtn.onClick.AddListener(() => LevelSceneButtonOnClick());
    //skipBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene));
    quitBtn.onClick.AddListener(() => MenuSceneButtonOnClick());
    }

    void LevelSceneButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.GeneralDesign);
    }

    void MenuSceneButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.MenuScene);
    }

    public void ButtonOnHover()
    {
        AudioManager.Instance.PlayGlobal(buttonHover);

    }
}
