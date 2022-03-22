using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject deck;
    private Deck deckClass;
    private GameObject deckReference;
    public UIManager uiManager;
    public MultiplayerHandler multiplayerHandler;
    private void Awake()
    {
        multiplayerHandler.OnStartGame.AddListener(() =>
        {
            SpawnDeck();
        });
        multiplayerHandler.OnFirstPlayer.AddListener(() => {
            deckClass.ShuffleDeck();
        });
        MultiplayerHandler.OnServerMessage += uiManager.AddMessageToLog;
    }
    public void SpawnDeck()
    {
        deckReference = Instantiate(deck);
        deckClass = deckReference.GetComponent<Deck>();
    }
}
