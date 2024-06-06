using System;
using System.Collections;
using UnityEngine;

public class SamuraiAlly : Samurai
{
    private void Awake()
    {
        AttackCommand.OnAttackRecognized += Attack;
    }

    private void Attack(AttackCommand command)
    {
        StartCoroutine(MoveUpDownFast());
    }

    private void OnDestroy()
    {
        AttackCommand.OnAttackRecognized -= Attack;
    }

    private IEnumerator MoveUpDownFast()
    {
        float speed = 5.0f; 
        float distance = 1.0f; 
        Vector3 originalPosition = transform.position;

        while (transform.position.y < originalPosition.y + distance)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }

        while (transform.position.y > originalPosition.y)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
    }
}
