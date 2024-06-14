using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAnimationControl : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", rb.velocity.magnitude > 0.05f);
    }
}
