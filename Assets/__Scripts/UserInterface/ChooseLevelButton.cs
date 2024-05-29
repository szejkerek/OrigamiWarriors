using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChooseLevelButton : MonoBehaviour
{
    const int k_startLevelIndex = SceneConstants.Level_1;
    [Header("Level Loader")]
    [SerializeField] int levelIndex;
    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LoadLevel(levelIndex));
    }

    private void LoadLevel(int levelIndex)
    {
        int currentIndex = levelIndex + k_startLevelIndex;
        SceneLoader.Instance.LoadScene(currentIndex);
    }
}
