using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class EchoEffect : MonoBehaviour
{
    [SerializeField]
    private ColorSO colorSO;
    [SerializeField]
    private float leastVelocity;
    private float timeSpawn;
    public float startTimeSpawn;
    public float destroyTime;
    public GameObject[] echo;
    void Start()
    {
        colorSO = GetComponent<Ball>().colorSO;
    }
    void Update()
    {
        //Will only instantiate if the ball is moving
        //It will instantiate the echo effect faster if the ball is moving faster
        float velocity = GetComponent<Rigidbody2D>().velocity.magnitude;
        float v = Mathf.Pow(velocity, 0.75f);
        if(v <= 0.2) return;
        float timeWait= startTimeSpawn / v;
        if (timeSpawn <= 0)
        {
            SpawnEcho();    
            timeSpawn = timeWait;
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }

    void SpawnEcho()
    {
        int rand = UnityEngine.Random.Range(0, echo.Length);
        GameObject obj = Instantiate(echo[rand], transform.position, Quaternion.identity);
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer) spriteRenderer.color = colorSO.color;
        Destroy(obj, destroyTime);
    }

}
