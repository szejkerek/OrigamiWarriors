
using UnityEngine.AddressableAssets;

[System.Serializable]
public class AssetReferenceItemSO : AssetReferenceT<ItemSO>
{
    public AssetReferenceItemSO(string guid) : base(guid) { }
}

[System.Serializable]
public class AssetReferenceCharacterSO : AssetReferenceT<CharacterSO>
{
    public AssetReferenceCharacterSO(string guid) : base(guid) { }
}