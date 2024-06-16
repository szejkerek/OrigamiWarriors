using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GeneralAnimationControl : BaseAnimationControl
{
    CharacterController cc;

    protected override void Start()
    {
        base.Start();
        cc = GetComponent<CharacterController>();
    }

    protected override Vector3 GetVelocity()
    {
        Debug.Log(cc.velocity);
        return cc.velocity;       
    }
}
