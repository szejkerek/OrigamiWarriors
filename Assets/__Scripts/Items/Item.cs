using UnityEngine.AddressableAssets;

public class Item : IDisplayable
{
    public string IconGUID { get; set; }
    public string DisplayName { get; set; }
    public int MaxLevel { get; set; }
    public int Level { get; set; }
    public int Cost { get; set; }
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
