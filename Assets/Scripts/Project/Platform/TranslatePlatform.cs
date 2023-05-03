using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TranslatePlatform : Platform, ITranslateable
{

    [SerializeField] private List<Transform> wayPoints;
    public List<Transform> WayPoints => wayPoints;


    private int _currentWayPoint = 0;

    private bool keydown;

    [SerializeField] private bool customStartPos = false;


    private void Start()
    {
        _currentWayPoint = 0;
        if (!customStartPos)
        {
            rb.MovePosition(WayPoints[0].position);
        }
    }


    private void Update()
    {
        keydown = Input.GetKey(keyCode);
    }

    void FixedUpdate()
    {
        if (!keydown)
        {
            return;
        }
        var position = rb.transform.position;
        var target =
            Vector3.MoveTowards(
                position, 
                WayPoints[_currentWayPoint].transform.position,
                moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(target);
        if (
            Vector3.Distance(
                WayPoints[_currentWayPoint].transform.position,
                rb.transform.position) <= 0.1
            )
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