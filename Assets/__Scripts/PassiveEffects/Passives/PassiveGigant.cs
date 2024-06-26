using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/Gigant")]
public class PassiveGigant : PassiveEffectSO
{
    public override string GetDesctiption()
    {
        return $"armor i obrażenia są *200%, większy rozmiar postac";
    }

    public override string GetName()
    {
        return "Wielki";
    }

    public override void OnStart(SamuraiEffectsManager context)
    {
        context.transform.localScale *= 1.3f;
        context.Owner.temporaryStats.Armor += context.Owner.GetStats().Armor;
        context.Owner.temporaryStats.Damage += context.Owner.GetStats().Damage;
    }
}
