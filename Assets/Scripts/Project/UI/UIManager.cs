using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private float winWaitTime = 1f;
    [SerializeField] private GameObject keyTipText;
    [SerializeField] private GameObject restartTipText;

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
                keyTipText.SetActive(true);
                restartTipText.SetActive(false);
                break;
            case GameState.GAME_LOST:
                restartTipText.SetActive(true);
                break;
            case GameState.GAME_WON:
                DisplayGameWinScreen();
                break;
            default:
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
}
