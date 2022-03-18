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
        multiplayerHandler.OnFirstPlayer.AddListener(() => {
            deckReference.GetComponent<Deck>().ShuffleDeck();
            //deckClass.PrintDeck();
        });
        MultiplayerHandler.OnServerMessage += uiManager.AddMessageToLog;
    }
    public void SpawnDeck()
    {
        deckReference = Instantiate(deck);
        deckClass = deckReference.GetComponent<Deck>();
    }
}
