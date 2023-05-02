using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TranslatePlatformSpring : Platform, ITranslateable
{
    [SerializeField] private List<Transform> wayPoints;
    public List<Transform> WayPoints => wayPoints;

    private bool keydown;
    private int _moveDirection = 1;
    
    public int _currentWayPoint = 0;
    

    private void Start()
    {
        _currentWayPoint = 0;
        rb.MovePosition(WayPoints[0].position);
    }

    private void Update()
    {
        keydown = Input.GetKey(keyCode);
    }

    void FixedUpdate()
    {
        if (keydown)
        {
            _moveDirection = 1;
        }
        else
        {
            _moveDirection = -1;
        }
        
        if ((_moveDirection == 1 && _currentWayPoint == WayPoints.Count)
            || (_moveDirection == -1 && _currentWayPoint == 0))
        {
            return;
        }
        var position = rb.transform.position;
        var targetWayPoint = _moveDirection == 1 ? _currentWayPoint : _currentWayPoint - 1;
        var wayPointPos = WayPoints[targetWayPoint].transform.position;
        var target =
            Vector3.MoveTowards(
                position, 
                wayPointPos,
                moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(target);
        if (
            Vector3.Distance(
                WayPoints[targetWayPoint].transform.position,
                rb.transform.position) <= 0.1
        )
        {
            _currentWayPoint += _moveDirection;
        }
        
        if (_currentWayPoint == -1)
        {
            _currentWayPoint = 0;
        }

        if (_currentWayPoint == WayPoints.Count)
        {
            _currentWayPoint = WayPoints.Count - 1;
        }
    }
}