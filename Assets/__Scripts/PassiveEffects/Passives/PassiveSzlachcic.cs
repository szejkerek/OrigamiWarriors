using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/Szlachcic")]
public class PassiveSzlachcic : PassiveEffectSO
{
    public int GoldPerLevel;

    public override string GetDesctiption()
    {
        return $"każdy odwiedzony pokój/level daje +{GoldPerLevel} złota";
    }

    public override string GetName()
    {
        return "Szlachcic";
    }

    public override void OnStart(SamuraiEffectsManager context)
    {
        SavableDataManager.Instance.data.playerResources.AddMoney(GoldPerLevel);
    }
}