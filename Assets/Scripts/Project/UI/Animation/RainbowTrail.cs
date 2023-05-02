using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RainbowTrail : MonoBehaviour
{
    public float duration = 2.0f;  // The duration for each color transition
    private TrailRenderer trailRenderer;

    void Start()
    {
        // Get the Trail Renderer component
        trailRenderer = GetComponent<TrailRenderer>();

        // Define the colors of the rainbow
        List<Color> rainbowColors = new List<Color>()
        {
            Color.red,
            new Color(1, 0.5f, 0), // Orange
            Color.yellow,
            Color.green,
            Color.blue,
            new Color(0.5f, 0, 1), // Indigo
            new Color(0.29f, 0, 0.51f) // Violet
        };

        // Start the color sequence
        StartCoroutine(ColorSequence(rainbowColors));
    }

    IEnumerator ColorSequence(List<Color> colors)
    {
        while (true)  // Loop forever
        {
            foreach (Color color in colors)
            {
                // Tween to the next color
                GetComponent<Renderer>().material.DOColor(color, duration);
                UpdateTrailColor(color);

                // Wait for the tween to complete before moving to the next color
                yield return new WaitForSeconds(duration);
            }
        }
    }

    void UpdateTrailColor(Color color)
    {
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0] = new GradientColorKey(color, 0.0f);
        colorKeys[1] = new GradientColorKey(color, 1.0f);

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphaKeys[1] = new GradientAlphaKey(0.0f, 1.0f);

        gradient.SetKeys(colorKeys, alphaKeys);
        trailRenderer.colorGradient = gradient;
    }
}
