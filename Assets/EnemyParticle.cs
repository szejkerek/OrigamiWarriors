using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    [SerializeField] Transform ObjectToFollow;
    [SerializeField] Enemy enemy;


    private void Start()
    {
        enemy.particles = transform.gameObject;
        transform.parent = null;
        StartCoroutine(ActivateParticles());
    }

    private void Update()
    {
        if(ObjectToFollow != null) transform.position =  ObjectToFollow.position;
    }

    IEnumerator ActivateParticles()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<ParticleSystem>().Play();
    }
}

