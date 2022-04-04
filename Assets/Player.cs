using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player
{
    public Deck hand { get; set; } = new Deck();
    //add to class diagram as a change to PlayerStateEnum
    public TurnState turnState { get; private set; } = TurnState.NotMyTurn;
    public LiarState liarState { get; private set; } = LiarState.Neutral;
    
    public Player()
    {
        hand = new Deck();
        turnState = TurnState.NotMyTurn;
        liarState = LiarState.Neutral;
    }
}
public enum TurnState
{
    NotMyTurn,
    Start,
    End
}
public enum LiarState
{
    Lie,
    Truth,
    Neutral
}