using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TranslatePlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private string buttonName;
    
    private int _currentWayPoint = 0;
    

    private void Start()
    {
        _currentWayPoint = 0;
        rb.MovePosition(wayPoints[0].position);
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(CustomUtils.ParseKeyCode(buttonName)))
        {
            return;
        }
        var position = rb.transform.position;
        var target =
            Vector3.MoveTowards(
                position, 
                wayPoints[_currentWayPoint].transform.position,
                moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(target);
        if (
            Vector3.Distance(
                wayPoints[_currentWayPoint].transform.position,
                rb.transform.position) <= 0.1
            )
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