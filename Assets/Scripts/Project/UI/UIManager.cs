using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private float winWaitTime = 1f;
    [SerializeField] private GameObject keyTipText;
    [SerializeField] private GameObject restartTipText;
    [SerializeField] private GameObject startTipText;

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
        switch(GameManager.Instance.gameState){
            case GameState.IN_GAME:
                startTipText.SetActive(false);
                keyTipText.SetActive(true);
                break;
            case GameState.PRE_GAME:
                startTipText.SetActive(true);
                keyTipText.SetActive(false);
                restartTipText.SetActive(false);
                break;
            case GameState.GAME_LOST:
                restartTipText.SetActive(true);
                break;
            case GameState.GAME_WON:
                DisplayGameWinScreen();
                break;
            default:
                startTipText.SetActive(false);
                keyTipText.SetActive(false);
                restartTipText.SetActive(false);
                break;
        }

    }

    private void DisplayGameWinScreen()
    {
        StartCoroutine(DisplayGameWinScreenCoroutine());
    }

    private IEnumerator DisplayGameWinScreenCoroutine()
    {
        yield return new WaitForSeconds(winWaitTime);
        gameWinScreen.SetActive(true);
    }

    public void ShowRestartTip(){
        restartTipText.SetActive(true);
    }
    
    public void HideStartTip(){
        startTipText.SetActive(false);
    }
}
