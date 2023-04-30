using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] [Required]
    private ColorSO colorSO;

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
        Ball ball = Ball.CreateBall(colorSO);
        ball.transform.position = transform.position;
        Vector2 launchDirection = (launchAtPoint.position - transform.position).normalized;
        ball.GetComponent<Rigidbody2D>().velocity = launchDirection * launchSpeed;
    }
}
