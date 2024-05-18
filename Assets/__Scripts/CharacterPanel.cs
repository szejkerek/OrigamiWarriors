using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] Transform upgradableStatsParent;
    [SerializeField] TMP_Text characterName;

    private void Awake() => ResetView();

    public void SetupView(Character character)
    {
        ResetView();
        characterName.text = character.displayName;
    }
    void ResetView()
    {
        foreach (Transform t in upgradableStatsParent)
        {
            Destroy(t.gameObject);
        }
    }
}
