using UnityEngine;
using UnityEngine.UI;

public class CreditsInterface : MonoBehaviour
{
  [SerializeField] Button backToMenuBtn = null;
  private void Awake()
  {
    backToMenuBtn.onClick.AddListener(() => SceneLoader.Instance.LoadScene(SceneConstants.MenuScene));
  }
}
