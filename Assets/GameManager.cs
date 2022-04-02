using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public UnityEvent OnGameStart;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameEnd;
    public UnityEvent OnAwake;
    public UIManager uiManager;
    GameState gameState;
    private void Awake()
    {
        OnAwake.Invoke();
        ChangeState(GameState.MainMenu);
    }
    public void StartGame(int playerCount)
    {
        ChangeState(GameState.Game);
        OnGameStart.Invoke();
    }
    public void PauseGame()
    {
        ChangeState(GameState.Pause);
        OnGamePause.Invoke();
    }
    public void EndGame()
    {
        ChangeState(GameState.MainMenu);
        OnGameEnd.Invoke();
    }
    private void ChangeState(GameState newState)
    {
        gameState = newState;
    }

}
public enum GameState
{
    MainMenu,
    Game,
    Pause
}
[Serializable]
public class GameStateUnityEventArgs: UnityEvent<GameState>
{ }
