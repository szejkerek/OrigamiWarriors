using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableSegment : MonoBehaviour
{
    [SerializeField] GameObject activeGameObject, inActiveGameObject;

    void Awake() => Deavtivate();

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
