using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformSpring : MonoBehaviour
{
    [SerializeField] private List<float> wayPoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string buttonName;

    private int _moveDirection = 1;
    
    public int _currentWayPoint = 0;
    

    private void Start()
    {
        _currentWayPoint = 0;
        for (int i = 0; i < wayPoints.Count; i++)
        {
            wayPoints[i] = Mathf.Repeat(wayPoints[i], 360);
        }
        rb.MoveRotation(wayPoints[0]);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(CustomUtils.ParseKeyCode(buttonName)))
        {
            _moveDirection = 1;
        }
        else
        {
            _moveDirection = -1;
        }
        
        if ((_moveDirection == 1 && _currentWayPoint == wayPoints.Count)
            || (_moveDirection == -1 && _currentWayPoint == 0))
        {
            return;
        }
        var position = rb.transform.eulerAngles.z;
        var targetWayPoint = _moveDirection == 1 ? _currentWayPoint : _currentWayPoint - 1;
        var wayPointPos = wayPoints[targetWayPoint];
        var target =
            Mathf.MoveTowardsAngle(
                position, 
                wayPointPos,
                moveSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(target);
        if (Mathf.Abs(wayPoints[targetWayPoint] - rb.transform.eulerAngles.z) <= 0.1)
        {
            _currentWayPoint += _moveDirection;
        }
        
        if (_currentWayPoint == -1)
        {
            _currentWayPoint = 0;
        }

        if (_currentWayPoint == wayPoints.Count)
        {
            _currentWayPoint = wayPoints.Count - 1;
        }
    }
}
