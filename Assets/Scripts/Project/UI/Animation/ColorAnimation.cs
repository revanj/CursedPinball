using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorAnimation : MonoBehaviour
{
    public float duration = 2.0f;  // The duration for each color transition

    void Start()
    {
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

                // Wait for the tween to complete before moving to the next color
                yield return new WaitForSeconds(duration);
            }
        }
    }
}
