using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.AI.Navigation;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] NavMeshSurface surface;

    private void Start()
    {
        FindObjectsOfType<Generator2>().ToList().ForEach(generator => { generator.Spawn();});
        //surface.BuildNavMesh();
    }
}
