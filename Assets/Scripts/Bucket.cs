using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] int ballsNeeded = 1;
    int ballsLeft;

    void Awake()
    {
        ballsLeft = ballsNeeded;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Ball>(out Ball ball))
        {
            return;
        }
        ballsLeft--;
        ballsLeft = Mathf.Max(0, ballsLeft);
    }

    public bool IsFull()
    {
        return ballsLeft <= 0;
    }
}
