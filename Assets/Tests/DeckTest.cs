using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DeckTest
{
    List<GameObject> cardModels = new List<GameObject> {
            new GameObject("PlayingCards_7Heart"),
            new GameObject("PlayingCards_2Spade"),
            new GameObject("PlayingCards_AHeart"),
            new GameObject("PlayingCards_JClub"),
            new GameObject("PlayingCards_7Spade"),
            new GameObject("PlayingCards_10Diamond")};
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
    [Test]
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
        Assert.AreEqual(Suits.Heart, popResult.suit);
    }
    [Test]
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
    [Test]
    public void InitializeDeckTest()
    {
        Deck deck = new Deck(cardModels);
        Assert.AreEqual("Heart 7; Spade 2; Heart 14; Club 11; Spade 7; Diamond 10; ", deck.ToString());
    }
    [Test]
    public void ShuffleDeckTest()
    {
        Deck deck = new Deck(cardModels);
        deck.ShuffleDeck();
        Assert.AreNotEqual("Heart 7", deck.cardModels[0].ToString());
    }
    [Test]
    public void PushTest()
    {
        Deck deck = new Deck(cardModels);
        deck.Push(new Card(new GameObject("PlayingCards_2Club")));
        Assert.AreEqual("Club 2", deck.deckCards[deck.deckCards.Count-1].ToString());
    }
}
