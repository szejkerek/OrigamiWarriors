using UnityEngine.AddressableAssets;

public class Item : IDisplayable
{
    public string IconGUID { get; }
    public string DisplayName { get; }
    public int MaxLevel { get; }
    public int Level { get; set; }
    public int Cost { get; }
    public ItemSO itemData {  get; }
    string itemDataGuid;

    public Item(string itemDataGuid)
    {
        this.itemDataGuid = itemDataGuid;
        itemData = new AssetReferenceItemSO(itemDataGuid).LoadAssetAsync<ItemSO>().WaitForCompletion();
        this.IconGUID = itemData.Icon.AssetGUID;
        this.DisplayName = itemData.DisplayName;
        this.MaxLevel = itemData.MaxLevel;
        this.Cost = itemData.Cost;
    }

    public int CostFunction()
    {
        return Cost * (Level+1);
    }

    public CharacterStats GetStats()
    {
        return itemData.CalculateLevelAdditions(this.Level);
    }

    public Item TryGetNextItem()
    {
        if(string.IsNullOrEmpty(itemData.NextItem.AssetGUID))
        {
            return null;
        }

        return new Item(itemData.NextItem.AssetGUID);
    }
}
