using UnityEngine;
using UnityEngine.UI;

public class ChooseLevelManager : MonoBehaviour
{
    [SerializeField] Button teamManagementBtn;
    [SerializeField] Button returnBtn;
    private void Awake()
    {
        teamManagementBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ManagementScene));
        returnBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.MenuScene));
    }

}
