using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeableStatInterface : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text displayName;
    [SerializeField] Transform segmentsParent;
    [SerializeField] StatSegment statSegmentPrefab;

    Stat currentStat;
    public void SetupDisplay(Stat stat)
    {
        currentStat = stat;
        icon.sprite = currentStat.Icon;
        displayName.text = currentStat.DisplayName;
    }

    void CreateSegments()
    {
        for (int i = 0; i < currentStat.MaxLevel; i++)
        {
            StatSegment segment = Instantiate(statSegmentPrefab, segmentsParent);
        }
    }
}
