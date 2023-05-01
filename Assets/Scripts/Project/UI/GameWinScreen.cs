using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinScreen : MonoBehaviour
{
    [SerializeField] GameObject gameWinScreen;
    [SerializeField] float winWaitTime = 1f;

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
        if (gameState != GameState.GAME_WON) { return; }

        DisplayGameWinScreen();
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
}
