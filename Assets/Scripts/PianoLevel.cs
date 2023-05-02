using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoLevel : MonoBehaviour
{
    [SerializeField] AudioClip soundC;
    [SerializeField] AudioClip soundD;
    [SerializeField] AudioClip soundE;
    [SerializeField] AudioClip soundF;
    [SerializeField] AudioClip soundG;
    [SerializeField] AudioClip soundA;
    [SerializeField] AudioClip soundB;

    [SerializeField] AudioSource bgmPlayer;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().mute = true;
    }

    void OnDestroy()
    {
        GameObject.FindWithTag("Music").GetComponent<AudioSource>().mute = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            audioSource.PlayOneShot(soundC);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            audioSource.PlayOneShot(soundD);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            audioSource.PlayOneShot(soundE);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(soundF);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            audioSource.PlayOneShot(soundG);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(soundA);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            audioSource.PlayOneShot(soundB);
        }
    }
}
