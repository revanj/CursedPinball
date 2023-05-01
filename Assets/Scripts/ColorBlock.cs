using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlock : MonoBehaviour
{

    [SerializeField] [Tooltip("It will automatically get the color from the parent platform")]
    private ColorSO colorSO;
    [SerializeField]
    private Collider2D _collider2D;
    private void Awake()
    {
        //get colorSo from parent
        colorSO = GetComponentInParent<Platform>().colorSO;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if color is required, check if the other object is a ball and if it is the same color
        //if not the same color, the collision will not happen

        if (!other.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            return;
        }
        //Debug.Log(ball.colorSO+" "+colorSO);
        if (ball.colorSO != colorSO)
        {
            //Debug.Log("Ball color is not the same as the color required");
            Physics2D.IgnoreCollision(other, _collider2D);
        }

    }
}
