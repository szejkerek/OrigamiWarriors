using UnityEngine;

[CreateAssetMenu]
public class PopupEventSO : ScriptableObject
{
    public string Header;
    public string Content;
    public Sprite DisplayImage;
    public PopupEventEffect OnAccept;
    public PopupEventEffect OnDecline;
}

[System.Serializable]
public class PopupEventEffect
{
    public int Money;
    public void Apply()
    {
        if (Money < 0)
        {
            SavableDataManager.Instance.data.playerResources.TryRemoveMoney(Money);
        }
        else
        {
            SavableDataManager.Instance.data.playerResources.AddMoney(Money);
        }
    }
}