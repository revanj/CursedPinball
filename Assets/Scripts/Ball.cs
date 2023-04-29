using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int ballGroup = 0;  // TODO: add ball group to color mapping

    public static GameObject ballPrefab;

    public static Ball CreateBall(int ballGroup)
    {
        GameObject ballObject = Instantiate(ballPrefab);
        Ball ball = ballObject.GetComponent<Ball>();
        ball.ballGroup = ballGroup;
        return ball;
    }
}
