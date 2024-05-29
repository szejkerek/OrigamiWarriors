using UnityEngine;
using UnityEngine.UI;

public class MenuInterface : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] Button quitBtn;

    private void Awake()
    {
        startBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene));
        quitBtn.onClick.AddListener(() => Application.Quit());
    }
}
