using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSegment : MonoBehaviour
{
    [SerializeField] GameObject activeGameObject, inActiveGameObject;

    public void Activate()
    {
        activeGameObject.SetActive(true);
        inActiveGameObject.SetActive(false);
    }

    public void Deavtivate() 
    {
        activeGameObject.SetActive(false);
        inActiveGameObject.SetActive(true);
    }
}
