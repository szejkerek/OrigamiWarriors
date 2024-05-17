using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StatSO))]
public class StatCustomEditor : Editor
{
    StatSO stat;

    private void OnEnable()
    {
        stat = target as StatSO;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (stat.Icon == null)
            return;

        Texture2D texture = AssetPreview.GetAssetPreview(stat.Icon);
        GUILayout.Label("", GUILayout.Height(80), GUILayout.Width(80));
        GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
    }
}