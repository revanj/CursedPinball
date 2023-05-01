using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject ballDiscretePrefab;

    void Awake()
    {
        Ball.ballPrefab = ballPrefab;
        Ball.ballDiscretePrefab = ballDiscretePrefab;
    }
}
