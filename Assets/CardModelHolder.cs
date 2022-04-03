using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add to this to class diagram
public class CardModelHolder : MonoBehaviour
{
    public List<GameObject> cardModels;
    Deck deck;
    void Start()
    {
        deck = new Deck(cardModels);
        List<Deck> decks = Deck.SplitDeck(deck, 3);
        Debug.Log(decks.Count);
        foreach (Deck deckers in decks)
        {
            Debug.Log("Another");
           
        }
    }
}
