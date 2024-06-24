using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Skill/Przyzywajacy")]
public class SkillPrzyzywajacy : ItemSO
{
    public GameObject KamiGhost;
    public int count;
    public float range;
    public override void Use(IUnit target, IUnit origin)
    {
        SamuraiEffectsManager manager = origin.gameObject.GetComponent<SamuraiEffectsManager>();
        if (manager == null)
            return;

        if (!Cooldown.IsOffCooldown())
            return;

        throw new NotImplementedException();
        Instantiate(KamiGhost);
        Cooldown.ResetTimers();
    }
}
