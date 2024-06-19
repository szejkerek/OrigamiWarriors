using UnityEngine;
using UnityEngine.UI;

public class LoreInterface : MonoBehaviour
{
  [SerializeField] Button startBtn = null;
  //[SerializeField] Button skipBtn = null;
  [SerializeField] Button quitBtn = null;

  private void Awake()
  {
    startBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene));
    //skipBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.ChooseLevelScene));
    quitBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.MenuScene));
  }
}
