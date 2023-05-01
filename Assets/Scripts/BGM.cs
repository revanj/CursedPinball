using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    public static bool PreservePrevious = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PreservePrevious)
        {
            Destroy(gameObject);
        }
    }
}
