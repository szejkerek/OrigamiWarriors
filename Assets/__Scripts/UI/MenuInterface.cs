using UnityEngine;
using UnityEngine.UI;

public class MenuInterface : MonoBehaviour
{
    [SerializeField] Button startBtn = null;
    [SerializeField] Button quitBtn = null;
    [SerializeField] Button creditsBtn = null;

    private void Awake()
    {
        startBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.LoreIntro));
        creditsBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.Credits));
        quitBtn.onClick.AddListener(() => Application.Quit());
    }
}
