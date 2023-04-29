using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    
    void Awake()
    {
        Ball.ballPrefab = ballPrefab;
    }
}
