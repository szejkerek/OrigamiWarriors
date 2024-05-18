using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    Character character;
    [SerializeField] UpgradeableStatInterface statPrefab;
    [SerializeField] Transform upgradableStatsParent;
    [SerializeField] TMP_Text characterName;

    private void Awake() => ResetView();

    public void SetupView(Character character)
    {
        this.character = character;
        ResetView();
        characterName.text = character.displayName;
        CreateStats();
    }
    void ResetView()
    {
        foreach (Transform t in upgradableStatsParent)
        {
            Destroy(t.gameObject);
        }
    }

    void CreateStats()
    {
        foreach(Stat s in character.stats)
        {
            UpgradeableStatInterface display = Instantiate(statPrefab, upgradableStatsParent);
            display.SetupDisplay(s);
        }
    }
}