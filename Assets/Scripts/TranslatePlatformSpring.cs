using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TranslatePlatformSpring : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string buttonName;

    private int _moveDirection = 1;
    
    public int _currentWayPoint = 0;
    

    private void Start()
    {
        _currentWayPoint = 0;
        rb.MovePosition(wayPoints[0].position);
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
        var position = rb.transform.position;
        var targetWayPoint = _moveDirection == 1 ? _currentWayPoint : _currentWayPoint - 1;
        var wayPointPos = wayPoints[targetWayPoint].transform.position;
        var target =
            Vector3.MoveTowards(
                position, 
                wayPointPos,
                moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(target);
        if (
            Vector3.Distance(
                wayPoints[targetWayPoint].transform.position,
                rb.transform.position) <= 0.1
        )
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