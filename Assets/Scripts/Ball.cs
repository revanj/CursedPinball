using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Rendering.Universal;


public class Ball : MonoBehaviour
{
    [Required]
    public ColorSO colorSO;
    public static GameObject ballPrefab;
    public static GameObject ballDiscretePrefab;
    private float time = 0;

    [SerializeField] private AudioSource audioSource;
    void Awake()
    {
        if (colorSO) Init(colorSO);
    }
    void Init(ColorSO colorSO)
    {
        this.colorSO = colorSO;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer) spriteRenderer.color = colorSO.color;

    }
    void Update()
    {
        // Destroy ball if it goes out of screen bounds, and change to lose state
        if (Utils.IsGameObjectOutOfScreenBoundsNotTop(this.gameObject, GameManager.Instance.mainCamera))
        {
            Explode();
            GameManager.Instance.TryChangeToLoseState();
        }
        if (GetComponent<Rigidbody2D>().velocity.magnitude < 0.1f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
        if (time > 3f)
        {
            UIManager.Instance.ShowRestartTip();
        }
    }

    void LateUpdate()
    {
        if (time == 0f)
        {
            UIManager.Instance.HideRestartTip();
        }
    }

    public static Ball CreateBall(ColorSO colorSO, bool UseDiscreteRigidbody2d)
    {
        GameObject ballPrefab_ = UseDiscreteRigidbody2d ? Ball.ballDiscretePrefab : Ball.ballPrefab;
        GameObject ballObject = Instantiate(ballPrefab_);
        Ball ball = ballObject.GetComponent<Ball>();
        ball.Init(colorSO);
        return ball;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        audioSource.volume = 1.2f;
        audioSource.pitch = UnityEngine.Random.Range(.6f, 1.2f);
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void Explode()
    {
        PixelExplosion pixelExplosion = GetComponent<PixelExplosion>();
        if (pixelExplosion) pixelExplosion.Explode();
        else Destroy(gameObject);
    }

}
