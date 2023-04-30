using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLossTransitionPanel : MonoBehaviour
{
    [SerializeField] Image transitionPanel;
    [SerializeField] float fadeTime;

    [SerializeField] AnimationCurve fadeInCurve;
    [SerializeField] AnimationCurve fadeOutCurve;

    public void FadeIn(FadeType fadeType)
    {
        StartCoroutine(FadeInCoroutine(fadeType));
    }

    private IEnumerator FadeInCoroutine(FadeType fadeType)
    {
        AnimationCurve fadeCurve;
        switch (fadeType)
        {
            case FadeType.FADE_IN:
                fadeCurve = fadeInCurve;
                break;
            case FadeType.FADE_OUT:
                fadeCurve = fadeOutCurve;
                break;
            default:
                throw new System.Exception("Invalid fade type");
        }
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            float alpha = fadeCurve.Evaluate(elapsedTime / fadeTime);
            SetTransitionPanelColorAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SetTransitionPanelColorAlpha(fadeCurve.Evaluate(1f));
    }

    private void SetTransitionPanelColorAlpha(float alpha)
    {
        Color transitionPanelColor = transitionPanel.color;
        transitionPanelColor.a = alpha;
        transitionPanel.color = transitionPanelColor;
    }

    public enum FadeType {
        FADE_IN,
        FADE_OUT
    }
}
