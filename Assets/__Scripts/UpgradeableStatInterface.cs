using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeableStatInterface : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TMP_Text displayName;

    public void SetupDisplay(Stat stat)
    {
        icon.sprite = stat.Icon;
        displayName.text = stat.DisplayName;
    }
}
