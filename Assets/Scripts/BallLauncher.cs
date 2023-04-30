using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] int ballGroup = 0;

    [SerializeField] Transform launchAtPoint;
    [SerializeField] float launchSpeed = 0f;

    void Awake()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState gameState)
    {
        if (gameState != GameState.IN_GAME) { return; }

        LaunchBall();
    }

    private void LaunchBall()
    {
        Ball ball = Ball.CreateBall(ballGroup);
        ball.transform.position = transform.position;
        Vector2 launchDirection = (launchAtPoint.position - transform.position).normalized;
        // Vector2 launchDirection = launchAtPoint.transform.rotation;
        ball.GetComponent<Rigidbody2D>().velocity = launchDirection * launchSpeed;
    }
}
