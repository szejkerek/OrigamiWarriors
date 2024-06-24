using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] Button teamManagementBtn;
    [SerializeField] Button returnBtn;

    [SerializeField] Sound buttonHover = null;
    [SerializeField] Sound buttonPressed = null;

    private void Awake()
    {
        teamManagementBtn.onClick.AddListener(() => ManagementButtonOnClick());
        returnBtn.onClick.AddListener(() => MenuButtonOnClick());
    }

    void ManagementButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.ManagementScene);
    }
    void MenuButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.MenuScene);
    }

    public void ButtonOnHover()
    {
        AudioManager.Instance.PlayGlobal(buttonHover);

    }

}
