using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Don't use this class
public class LossBucket : MonoBehaviour
{
    // Decide exact implementation later, or if should be a special case of Bucket

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<Ball>(out Ball ball))
        {
            return;
        }
        
        GameManager.Instance.TryChangeToLoseState();
    }
}
