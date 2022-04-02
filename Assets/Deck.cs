using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Deck : MonoBehaviour
{
    private List<Card> deckCards;
    public event EventHandler<OnDeckChangedEventArgs> OnCardRemoved;
    public event EventHandler<OnDeckChangedEventArgs> OnCardAdded;
    GameObject owner;

    //add this to class diagram
    public List<GameObject> cardModels;

    void Awake()
    {
        deckCards = new List<Card>();
    }
    private void Start()
    {
        InitializeDeckCards();
        ShuffleDeck();
    }
    private void InitializeDeckCards()
    {
        if (cardModels == null)
            return;

        foreach (GameObject cardModel in cardModels)
        {
            deckCards.Add(new Card(cardModel));
        }
    }

    public void ShuffleDeck()
    {
        List<Card> cards = new List<Card>();
        int length = deckCards.Count; 
        while(length>0)
        {
            int randomIndex = UnityEngine.Random.Range(0, length);
            cards.Add(deckCards[randomIndex]);
            deckCards.RemoveAt(randomIndex);
            length--;
        }
        deckCards = cards;
        PrintDeck();
    }

    //add this to class diagram
    public List<Card> SplitDeck(int parts)
    {
        //todo function for spliting a deck into parts
        return null;
    }
    public void Push(Card card, GameObject source)
    {
        deckCards.Add(card);

        OnCardAdded?.Invoke(this, new OnDeckChangedEventArgs(card, source));
    }
    public Card Pop(GameObject loser)
    {
        Card removed = deckCards[deckCards.Count - 1];
        deckCards.RemoveAt(deckCards.Count-1);
        OnCardRemoved?.Invoke(this, new OnDeckChangedEventArgs(removed, loser));
        return removed; 
    }
    public List<Card> GetDeck()
    {
        return deckCards;
    }
    public void AddDeck(Deck deck, GameObject from)
    {
        List<Card> cardsToAdd = deck.GetDeck();
        foreach(Card card in cardsToAdd)
        {
            Push(card, from);
        }
    }
    public GameObject GetOwner()
    {
        return owner;
    }
    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }
    
    public void PrintDeck()
    {
        foreach (Card card in deckCards)
            Debug.Log(card.ToString());
    }
}
public class OnDeckChangedEventArgs : EventArgs {
    Card card;
    GameObject caller;
    public OnDeckChangedEventArgs(Card card) {
        this.card = card;
        caller = null;
    }
    public OnDeckChangedEventArgs(Card card, GameObject caller)
    {
        this.card = card;
        this.caller = caller; 
    }
}

