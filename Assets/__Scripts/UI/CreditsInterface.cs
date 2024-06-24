using UnityEngine;
using UnityEngine.UI;

public class CreditsInterface : MonoBehaviour
{
  [SerializeField] Button backToMenuBtn = null;

    [SerializeField] Sound buttonHover = null;
    [SerializeField] Sound buttonPressed = null;
    private void Awake()
  {
    backToMenuBtn.onClick.AddListener(() => BacktButtonOnClick());
  }

    void BacktButtonOnClick()
    {
        AudioManager.Instance.PlayGlobal(buttonPressed);
        SceneLoader.Instance.LoadScene(SceneConstants.MenuScene);
    }

    public void ButtonOnHover()
    {
        AudioManager.Instance.PlayGlobal(buttonHover);

    }

}
