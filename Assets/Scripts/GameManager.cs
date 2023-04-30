using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: Singleton<GameManager>
{
    [SerializeField] float timeAfterLosingToRestart = 1f;
    
    GameState gameState;

    public static event Action<GameState> OnGameStateChanged;
    
    void Awake()
    {
        ChangeState(GameState.IN_GAME);
    }

    public void ChangeState(GameState newState)
    {
        if (newState == gameState) { return; }  // Necessary?
        
        GameState prevState = gameState;
        gameState = newState;

        switch (gameState)
        {
            case GameState.NOT_PLAYING:
                break;
            case GameState.PRE_GAME:
                HandlePreGame();
                break;
            case GameState.IN_GAME:
                break;
            case GameState.GAME_WON:
                HandleGameWon();
                break;
            case GameState.GAME_LOST:
                HandleGameLost();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        if (gameState != prevState)
        {
            OnGameStateChanged?.Invoke(gameState);
        }
    }

    public void TryChangeToWinState()
    {
        if (gameState == GameState.IN_GAME)  // Most importantly, not in GAME_LOST
        {
            ChangeState(GameState.GAME_WON);
        }
    }

    public void TryChangeToLoseState()
    {
        if (gameState == GameState.IN_GAME)  // Most importantly, not in GAME_WON
        {
            ChangeState(GameState.GAME_LOST);
        }
    }

    private void HandlePreGame()
    {
        ChangeState(GameState.IN_GAME);
    }

    private void HandleGameWon()
    {
        Debug.Log("Game won!");
    }

    private void HandleGameLost()
    {
        Debug.Log($"Game lost! Restarting in {timeAfterLosingToRestart} seconds...");
        StartCoroutine(HandleGameLostCoroutine());
    }
    private IEnumerator HandleGameLostCoroutine()
    {
        yield return new WaitForSeconds(timeAfterLosingToRestart);
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

public enum GameState
{
    NOT_PLAYING,
    PRE_GAME,
    IN_GAME,
    GAME_WON,
    GAME_LOST,
}
