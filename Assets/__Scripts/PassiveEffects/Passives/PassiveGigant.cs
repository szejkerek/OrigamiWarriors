using UnityEngine;

[CreateAssetMenu(menuName = "Character/Passsives/Gigant")]
public class PassiveGigant : PassiveEffectSO
{
    public override string GetDesctiption()
    {
        return $"życie *200%, większy rozmiar postac";
    }

    public override string GetName()
    {
        return "Wielki";
    }

    public override void OnStart(SamuraiEffectsManager context)
    {
        context.transform.localScale *= 1.3f;
        context.Owner.temporaryStats.MaxHealth *= 2;
        context.Owner.HealToMax();
    }
}
