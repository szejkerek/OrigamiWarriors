using Tayx.Graphy.Audio;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class MenuInterface : MonoBehaviour
{
    [SerializeField] Button startBtn = null;
    [SerializeField] Button quitBtn = null;
    [SerializeField] Button creditsBtn = null;

    [SerializeField] Sound buttonHover = null;
    [SerializeField] Sound buttonPressed = null;
    [SerializeField] Sound menuAmbient = null;

    private void Awake()
    {
        startBtn.onClick.AddListener(() => StartButtonOnClick());
        creditsBtn.onClick.AddListener(() => CreditsButtonOnClick());
        quitBtn.onClick.AddListener(() => QuitButtonOnClick());
    }

    public void Start()
    {
        //AudioManager.Instance.PlayGlobal(menuAmbient, SoundType.Music);
    }

    void StartButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.LoreIntro);
    }
    void CreditsButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.Credits);
    }
    void QuitButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        Application.Quit();
    }

    public void ButtonOnHover()
    {
        AudioManager.Instance.PlayGlobal(buttonHover);

    }



}
