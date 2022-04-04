using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DeckTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void PopTestValue()
    {
        //Deck
        GameObject Deck = new GameObject("Deck");
        Deck deckComponent = new Deck();
        //card mockup
        Card card = new Card(new GameObject("PlayingCards_2Club"));
        //add card to deck
        deckComponent.Push(card);
        //remove the last card on the deck and return it
        Card popResult = deckComponent.Pop();
        //test
        Assert.AreEqual(2, popResult.value);
    }
    public void PopTestSuit()
    {
        //Deck
        GameObject Deck = new GameObject("Deck");
        Deck deckComponent = new Deck();
        //card mockup
        Card card = new Card(new GameObject("PlayingCards_7Heart"));
        //add card to deck
        deckComponent.Push(card);
        //remove the last card on the deck and return it
        Card popResult = deckComponent.Pop();
        //test
        Assert.AreEqual(Suits.Club, popResult.suit);
    }
    public void EmptyDeckPopTest()
    {
        //Deck
        GameObject Deck = new GameObject("Deck");
        Deck deckComponent = new Deck();
        //card mockup

        Card popResult = deckComponent.Pop();
        //test
        Assert.AreEqual(null, popResult);
    }

}
