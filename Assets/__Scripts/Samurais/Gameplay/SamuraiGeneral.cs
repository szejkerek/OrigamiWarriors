using Cinemachine;
using System;
using UnityEngine;

public class SamuraiGeneral : Samurai
{
    public static Action<Samurai> OnDeath;
    [SerializeField] LayerMask m_Mask;
    private Camera mainCamera;
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        SetupCamera();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CursorManager.Instance.SetCooldownOnCursor(Character.Weapon.itemData.Cooldown.cooldowTime);
            CastRayAndAttack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            CursorManager.Instance.SetCooldownOnCursor(Character.Skill.itemData.Cooldown.cooldowTime);
            UseSkill();
        }
    }

    private void SetupCamera()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
            // Assuming the Main Camera is the one used by Cinemachine
            mainCamera = Camera.main;
        }
    }

    private void CastRayAndAttack()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, 1500f, m_Mask);

        foreach (RaycastHit hit in hits)
        {
            IUnit unit = hit.collider.GetComponent<IUnit>();
            if (unit != null && !unit.IsAlly)
            {               
                AttackTarget(unit);
            }
        }
    }

    protected override void OnSamuraiDeath()
    {
        OnDeath?.Invoke(this);
    }
}
