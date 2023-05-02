using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Bucket : MonoBehaviour
{
    [SerializeField] [Required]
    ColorSO colorSO;

    [SerializeField] int ballsNeeded = 1;
    int ballsLeft;

    [SerializeField] Transform colorParent;
    [Tooltip("If true, the bucket will destory the ball")]
    [SerializeField] private bool isDestroyOnFull = false;
    void Awake()
    {
        ballsLeft = ballsNeeded;
        //get sprite renderer in all children
        SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = colorSO.color;
        }
    }

    void Start()
    {
        BucketManager.Instance.RegisterBucket(this);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Ball>(out Ball ball))
        {
            return;
        }
        if(ball.colorSO != colorSO)
        {
            return;
        }
        ballsLeft--;
        ballsLeft = Mathf.Max(0, ballsLeft);
        if (IsFull())
        {
            BucketManager.Instance.AddFullBucket(this);
        }
        if(isDestroyOnFull)
        {
            ball.GetComponent<Ball>().Explode();
        }
    }

    public bool IsFull()
    {
        return ballsLeft <= 0;
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
