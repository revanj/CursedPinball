using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: Singleton<GameManager>
{
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

    public void HandlePreGame()
    {
        ChangeState(GameState.IN_GAME);
    }

    public void HandleGameWon()
    {
        Debug.Log("Game won!");
    }

    public void HandleGameLost()
    {
        Debug.Log("Game lost!");
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
