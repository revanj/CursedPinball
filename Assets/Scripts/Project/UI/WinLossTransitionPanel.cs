using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLossTransitionPanel : MonoBehaviour
{
    [SerializeField] Image transitionPanel;
    [SerializeField] float fadeTime;
    [SerializeField] float fadeDelay;

    [SerializeField] AnimationCurve fadeInCurve;
    [SerializeField] AnimationCurve fadeOutCurve;

    void Awake()
    {
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.GAME_LOST:
                StartCoroutine(FadeDelay());
                break;
            case GameState.PRE_GAME:
                Fade(FadeType.FADE_OUT);
                break;
            default:
                break;
        }
    }

    public void Fade(FadeType fadeType)
    {
        StartCoroutine(FadeCoroutine(fadeType));
    }
    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(fadeDelay);
        Fade(FadeType.FADE_IN);
    }
    private IEnumerator FadeCoroutine(FadeType fadeType)
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
