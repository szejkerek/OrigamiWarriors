using TMPro;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    Character character;
    [SerializeField] UpgradeableItemDisplay statPrefab;
    [SerializeField] Transform upgradableStatsParent;
    [SerializeField] TMP_Text characterName;

    private void Awake() => ResetView();

    public void SetupView(Character character)
    {
        this.character = character;
        characterName.text = character.DisplayName;
        
        CreateStats();
    }

    void CreateStats()
    {
        ResetView();
        foreach (Stat s in character.stats)
        {
            UpgradeableItemDisplay display = Instantiate(statPrefab, upgradableStatsParent);
            display.Init(s);
        }
    }

    void ResetView()
    {
        foreach (Transform t in upgradableStatsParent)
        {
            Destroy(t.gameObject);
        }
    }
}
