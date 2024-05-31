using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public Material baseMaterial;
    private Material newMaterial;
    public MeshRenderer renderer;

    public List<Transform> transforms;
    public Interval<float> scaleModifier;


    public void Awake()
    {
        newMaterial = Instantiate(baseMaterial);
        renderer.materials[0] = newMaterial;

        foreach(Transform t in transforms)
        {
            t.localScale = new Vector3(t.localScale.x * scaleModifier.GetValueBetween(), t.localScale.y * scaleModifier.GetValueBetween(), t.localScale.z * scaleModifier.GetValueBetween());
        }
    }


    public void GetDamage(float amount)
    {
        foreach (Transform t in transforms)
        {
            t.localScale = new Vector3(t.localScale.x * amount, t.localScale.y * amount, t.localScale.z * amount);
        }
    }


    public void Update()
    {
        //GetDamage(1 - Time.deltaTime * 0.1f);
        //newMaterial.SetFloat("_Smooth", 0.5f);
    }
}
