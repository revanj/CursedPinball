using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformSpring : Platform, IRotateable
{
    [SerializeField] private List<float> wayPoints;
    public List<float> WayPoints => wayPoints;


    private int _moveDirection = 1;
    
    public int _currentWayPoint = 0;
    

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
        if (Input.GetKey(keyCode))
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
        var position = rb.transform.eulerAngles.z;
        var targetWayPoint = _moveDirection == 1 ? _currentWayPoint : _currentWayPoint - 1;
        var wayPointPos = WayPoints[targetWayPoint];
        var target =
            Mathf.MoveTowardsAngle(
                position, 
                wayPointPos,
                moveSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(target);
        if (Mathf.Abs(WayPoints[targetWayPoint] - rb.transform.eulerAngles.z) <= 0.1)
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
