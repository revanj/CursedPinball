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
    [SerializeField] bool UseDiscreteRigidbody2d = false;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] Transform colorParent;

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
        Ball ball = Ball.CreateBall(colorSO, UseDiscreteRigidbody2d);
        ball.transform.position = transform.position;
        Vector2 launchDirection = launchAtPoint.up;
        ball.GetComponent<Rigidbody2D>().velocity = launchDirection * launchSpeed;
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void OnValidate()
    {
        if (colorParent == null) { return; }
        SpriteRenderer[] spriteRenderers = colorParent.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = colorSO.color;
        }
    }
}
