using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float speed = 1.0f;
    public float radius = 1.0f;

    private float angle = 0.0f;
    private Vector2 center;
    void Awake(){
        center = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector2(x, y) + center;
    }
}
