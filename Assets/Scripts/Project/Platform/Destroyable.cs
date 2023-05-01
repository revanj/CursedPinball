using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    private Collider2D _collider2D;
    [Tooltip("Set to -1 for infinite health")]
    [SerializeField]
    private int health = 1; 
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Ball>(out Ball ball))
        {
            return;
        }
        if (health == -1)
        {
            return;
        }
        health--;
        if (health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }

}
