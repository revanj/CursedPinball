using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: Singleton<GameManager>
{
    GameState gameState = GameState.PRE_GAME;

    public static event Action<GameState> OnGameStateChanged;
    
    void Awake()
    {
        
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
        
    }

    public void HandleGameLost()
    {

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
