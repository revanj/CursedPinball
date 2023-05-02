using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCQuitter : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            loader.LoadSceneNoPreserveBGM();
        }
    }
}
