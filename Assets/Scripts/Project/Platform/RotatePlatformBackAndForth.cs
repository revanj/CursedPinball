using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformBackAndForth : Platform, IRotateable
{
    [SerializeField] private List<float> wayPoints;
    public List<float> WayPoints => wayPoints;

    private bool keyDown;


    private int _currentWayPoint = 0;


    private void Start()
    {
        if (WayPoints.Count == 0) { return; }
        _currentWayPoint = 0;
        for (int i = 0; i < WayPoints.Count; i++)
        {
            WayPoints[i] = Mathf.Repeat(WayPoints[i], 360);
        }
        rb.MoveRotation(WayPoints[0]);
    }

    private void Update()
    {
        keyDown = Input.GetKey(keyCode);
    }

    void FixedUpdate()
    {
        if (!keyDown)
        {
            return;
        }
        var position = rb.transform.eulerAngles.z;
        float target;
        if (wayPoints.Count > 0)
        {
            target = Mathf.MoveTowardsAngle(
                position, WayPoints[_currentWayPoint], moveSpeed * Time.fixedDeltaTime
            );
        }
        else
        {
            target = position - moveSpeed * Time.fixedDeltaTime;
        }
        rb.MoveRotation(target);
        if (wayPoints.Count == 0) { return; }
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
