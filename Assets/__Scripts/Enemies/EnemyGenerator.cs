using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GordonEssentials;

public class EnemyGenerator : MonoBehaviour
{
    public Material baseMaterial;
    public MeshRenderer renderer;

    public List<Transform> transforms;
    //public localScaleMax = 1;
    public float localScaleMinModifier = 1;


    public void Awake()
    {
        Material newMaterial = Instantiate(baseMaterial);
        renderer.materials[0] = newMaterial;

        foreach(Transform t in transforms)
        {
            t.localScale
        }
    }

}
