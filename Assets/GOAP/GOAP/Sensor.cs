using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Linq;

public static class GameObjectExtensions
{
  /// Returns the object itself if it exists, null otherwise.
  public static T OrNull<T>(this T obj) where T : UnityEngine.Object => obj ? obj : null;
}

[RequireComponent(typeof(SphereCollider))] // every sensor has to have a collider of some sort
public class Sensor : MonoBehaviour
{
    [SerializeField] float detectionRadius = 5.0f; // radius of the sensor
    [SerializeField] float timerInterval = 1.0f; // how often to check the sensor (instead of every frame)
    [SerializeField] List<string> targetTags;
    private List<GameObject> targetsInRange;

    SphereCollider detectionRange;

    public event Action OnTargetChanged = delegate { };

    public Vector3 TargetPosition => target ? target.transform.position : Vector3.zero;
    public bool IsTargetInRange => TargetPosition != Vector3.zero;

    GameObject target;
    Vector3 lastKnownPosition;
    CountdownTimer timer;

    void Awake()
    {
        if (targetTags == null) targetTags = new List<string>();
        targetsInRange = new List<GameObject>();
        detectionRange = GetComponent<SphereCollider>();
        detectionRange.isTrigger = true;
        detectionRange.radius = detectionRadius;
    }

    void Start()
    {
        timer = new CountdownTimer(timerInterval);
        timer.OnTimerStop += () =>
        {
            UpdateTargetPosition();
            timer.Start();
        };
        timer.Start();
    }

    private void Update()
    {
        timer.Tick(Time.deltaTime);
    }

    void UpdateTargetPosition()
    {
        Debug.Log(targetsInRange.Count);
        if (targetsInRange.Count == 0) target = null;
        else
        {
            GameObject closestTarget = targetsInRange[0];
            float minDistance = 0;

            foreach (GameObject t in targetsInRange)
            {
                float currDistance = Vector3.Distance(transform.position, t.transform.position);
                if (currDistance < minDistance)
                {
                    minDistance = currDistance;
                    closestTarget = t;
                }
            }

            target = closestTarget;
        }

    if (IsTargetInRange && (lastKnownPosition != TargetPosition || lastKnownPosition != Vector3.zero))
    {
      lastKnownPosition = TargetPosition;
      OnTargetChanged.Invoke(); // target moved or new target
    }
  }

  //trigger collider for the player (JUST the player)
  void OnTriggerEnter(Collider other)
  {
    bool hasPropperTag = false;
    foreach (string s in targetTags) if (other.CompareTag(s)) hasPropperTag = true;

    if (!hasPropperTag) { return; }

    if (!targetsInRange.Contains(other.gameObject)) targetsInRange.Add(other.gameObject);

    UpdateTargetPosition();
  }
  
  //trigger collider for the player (JUST the player)
  void OnTriggerExit(Collider other)
  {
        bool hasPropperTag = false;
        foreach (string s in targetTags) if (other.CompareTag(s)) hasPropperTag = true;

        if (!hasPropperTag) { return; }

        if (targetsInRange.Contains(other.gameObject)) targetsInRange.Remove(other.gameObject);

        UpdateTargetPosition();
    }

  private void OnDrawGizmos() // visible when target is in range
  {
    Gizmos.color = IsTargetInRange ? Color.red : Color.green;
    Gizmos.DrawWireSphere(transform.position, detectionRadius);
  }
}
