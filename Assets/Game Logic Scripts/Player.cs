using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player
{
    public Deck hand { get; set; } = new Deck();
    //add to class diagram as a change to PlayerStateEnum
    public TurnState turnState { get; private set; } = TurnState.NotMyTurn;
    public LiarState liarState { get; set; } = LiarState.Neutral;

    public UnityEvent OnStartTurn = new UnityEvent();
    public UnityEvent OnTurnEnd = new UnityEvent();

    public Player()
    {
        hand = new Deck();
        turnState = TurnState.NotMyTurn;
        liarState = LiarState.Neutral;
    }
    public void StartTurn()
    {
        turnState = TurnState.Start;
        OnStartTurn.Invoke();
    }
    public void EndTurn()
    {
        turnState = TurnState.NotMyTurn;
        OnTurnEnd.Invoke();
    }
    public new string ToString()
    {
        return "Player";
    }
}
public enum TurnState
{
    NotMyTurn, //šiuo metu žaidėjas gali tiktais apkaltinti žaidėja
    Start,
    End
}
public enum LiarState
{
    Lie,
    Truth,
    Neutral
}