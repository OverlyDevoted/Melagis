using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Deck
{
    public List<Card> deckCards { get; private set; } = new List<Card>();
    public event EventHandler<OnDeckChangedEventArgs> OnCardRemoved;
    public event EventHandler<OnDeckChangedEventArgs> OnCardAdded;
    public GameObject owner { get; set; }

    //add this to class diagram
    public List<GameObject> cardModels;

    public Deck(List<GameObject>cardModels)
    {
        this.cardModels = cardModels;
        InitializeDeckCards();
    }

    public Deck() { }

    private void InitializeDeckCards()
    {
        if (cardModels == null)
            return;

        foreach (GameObject cardModel in cardModels)
        {
            deckCards.Add(new Card(cardModel));
        }
        Debug.Log(ToString());
    }

    public void ShuffleDeck()
    {
        if (deckCards.Count==0)
            return;

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
    }

    //add this to class diagram
    public static List<Deck> SplitDeck(Deck deck, int parts)
    {
        if(deck.deckCards.Count < parts) return null;

        List<Deck> returnDecks = new List<Deck>();
        
        for(int i=0;i<deck.deckCards.Count;i++)
        {
            if (i < parts)
            {
                returnDecks.Add(new Deck());
            }
            returnDecks[i%parts].Push(deck.deckCards[i]);
        }
        return returnDecks;
    }
    public void Push(Card card, GameObject source)
    {
        deckCards.Add(card);
        OnCardAdded?.Invoke(this, new OnDeckChangedEventArgs(card, source));
    }
    public void Push(Card card)
    {
        deckCards.Add(card);
        OnCardAdded?.Invoke(this, new OnDeckChangedEventArgs(card, null));
    }
    public Card Pop(GameObject loser)
    {
        if (deckCards.Count == 0)
            return null;
        Card removed = deckCards[deckCards.Count - 1];
        deckCards.RemoveAt(deckCards.Count-1);
        OnCardRemoved?.Invoke(this, new OnDeckChangedEventArgs(removed, loser));
        return removed; 
    }
    public Card Pop()
    {
        if (deckCards.Count == 0)
            return null;
        Card removed = deckCards[deckCards.Count - 1];
        deckCards.RemoveAt(deckCards.Count - 1);
        OnCardRemoved?.Invoke(this, new OnDeckChangedEventArgs(removed, null));
        return removed;
    }
    public void AddDeck(Deck deck, GameObject from)
    {
        List<Card> cardsToAdd = deck.deckCards;
        foreach(Card card in cardsToAdd)
        {
            Push(card, from);
        }
    }
    public static void Flush(Deck deck)
    {
        deck.deckCards.Clear();
    }

    public new string ToString()
    {
        string answer = "";
        foreach(Card card in deckCards)
            answer += card.ToString() + " ;";
        return answer;
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

