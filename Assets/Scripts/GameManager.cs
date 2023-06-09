using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: Singleton<GameManager>
{
    [SerializeField] float timeAfterLosingToRestart = 1f;
    
    public GameState gameState;

    public Camera mainCamera;
    public static event Action<GameState> OnGameStateChanged;
    
    void Update()
    {
        if ((gameState == GameState.IN_GAME || gameState == GameState.PRE_GAME) && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if (gameState == GameState.PRE_GAME && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(GameState.IN_GAME);
        }
        //detect whether 
    }
    void Awake(){
        if(mainCamera == null) mainCamera = FindObjectOfType<Camera>();
    }
    void Start()
    {
        ChangeState(GameState.PRE_GAME);
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
        BGM.PreservePrevious = true;
        GameObject.FindWithTag("Music").transform.parent = null;
        DontDestroyOnLoad(GameObject.FindWithTag("Music"));
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
