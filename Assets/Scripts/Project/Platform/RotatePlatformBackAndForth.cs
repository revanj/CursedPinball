using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformBackAndForth : Platform, IRotateable
{
    [SerializeField] private List<float> wayPoints;
    public List<float> WayPoints => wayPoints;


    private int _currentWayPoint = 0;


    private void Start()
    {
        _currentWayPoint = 0;
        for (int i = 0; i < WayPoints.Count; i++)
        {
            WayPoints[i] = Mathf.Repeat(WayPoints[i], 360);
        }
        rb.MoveRotation(WayPoints[0]);
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(keyCode))
        {
            return;
        }
        var position = rb.transform.eulerAngles.z;
        var target = 
            Mathf.MoveTowardsAngle(
                position, WayPoints[_currentWayPoint], moveSpeed * Time.fixedDeltaTime
            );
        rb.MoveRotation(target);
        if (Mathf.Abs(WayPoints[_currentWayPoint] - rb.transform.eulerAngles.z) <= 0.1)
        {
            _currentWayPoint++;
        }
        if (_currentWayPoint == WayPoints.Count)
        {
            WayPoints.Reverse();
            _currentWayPoint = 0;
        }
    }
}
