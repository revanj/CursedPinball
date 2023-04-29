using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatformBackAndForth : MonoBehaviour
{
    [SerializeField] private List<float> wayPoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string buttonName;
    
    private int _currentWayPoint = 0;
    

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
        if (!Input.GetKey(CustomUtils.ParseKeyCode(buttonName)))
        {
            return;
        }
        var position = rb.transform.eulerAngles.z;
        var target = 
            Mathf.MoveTowardsAngle(
                position, wayPoints[_currentWayPoint], moveSpeed * Time.fixedDeltaTime
            );
        rb.MoveRotation(target);
        if (Mathf.Abs(wayPoints[_currentWayPoint] - rb.transform.eulerAngles.z) <= 0.1)
        {
            _currentWayPoint++;
        }
        if (_currentWayPoint == wayPoints.Count)
        {
            wayPoints.Reverse();
            _currentWayPoint = 0;
        }
    }
}
