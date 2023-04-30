using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{

    public ColorSO colorSO;
    public static GameObject ballPrefab;

    void Init(ColorSO colorSO){
        this.colorSO = colorSO;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer) spriteRenderer.color = colorSO.color;
    }
    public static Ball CreateBall(ColorSO colorSO)
    {
        GameObject ballObject = Instantiate(ballPrefab);
        Ball ball = ballObject.GetComponent<Ball>();
        ball.Init(colorSO);
        return ball;
    }
}
