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
    void Awake() {
        if(colorSO) Init(colorSO);
    }
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
