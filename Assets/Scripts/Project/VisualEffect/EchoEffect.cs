using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class EchoEffect : MonoBehaviour
{
    [SerializeField]
    private ColorSO colorSO;
    private float timeSpawn;
    public float startTimeSpawn;
    public float destroyTime;
    public GameObject[] echo;
    void Start() {
        colorSO = GetComponent<Ball>().colorSO;
    }
    void Update(){
        if(timeSpawn <= 0){
            int rand = Random.Range(0, echo.Length);
            GameObject obj = Instantiate(echo[rand], transform.position, Quaternion.identity);
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if(spriteRenderer) spriteRenderer.color = colorSO.color;
            Destroy(obj, destroyTime);
            timeSpawn = startTimeSpawn;
            
        }else{
            timeSpawn -= Time.deltaTime;
        }
    }


}
