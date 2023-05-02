using UnityEngine;
using DG.Tweening;
using TMPro;

public class TipsAnimation : MonoBehaviour
{
    public TMP_Text textObject; // Assign your TextMeshPro object in the inspector
    public float animationDuration = 1f; // Duration of one 'pulse'
    public Vector3 maxScale = new Vector3(1.1f, 1.1f, 1.1f); // Maximum scale size
    public float minAlpha = 0.5f; // Minimum transparency

    void Start()
    {
        // Call the function to start the animation
        AnimateText();
    }

    void AnimateText()
    {
        // Save the original scale and original color
        Vector3 originalScale = textObject.transform.localScale;
        Color originalColor = textObject.color;

        // Create the animation
        Sequence sequence = DOTween.Sequence();

        // Add a scale up and fade out animation
        sequence.Append(textObject.transform.DOScale(maxScale, animationDuration));
        sequence.Join(textObject.DOColor(new Color(originalColor.r, originalColor.g, originalColor.b, minAlpha), animationDuration));

        // Add a scale down and fade in animation
        sequence.Append(textObject.transform.DOScale(originalScale, animationDuration));
        sequence.Join(textObject.DOColor(originalColor, animationDuration));

        // Loop the sequence indefinitely
        sequence.SetLoops(-1);

        // Start the sequence
        sequence.Play();
    }
}