using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BotTest
{
    List<GameObject> cardModels = new List<GameObject> {
            new GameObject("PlayingCards_7Heart"),
            new GameObject("PlayingCards_2Spade"),
            new GameObject("PlayingCards_AHeart"),
            new GameObject("PlayingCards_JClub"),
            new GameObject("PlayingCards_7Spade"),
            new GameObject("PlayingCards_10Diamond")};
    // Test which calculates which card to place based on optimistic algorithm
    [Test]
    public void CheckOptimisticBotAlgorithmDecision()
    {
        //bot hand
        Deck hand = new Deck(cardModels);
        
        Card topDeck = new Card(new GameObject("Heart 5"));
        
        //currently there's no algorithm that count what bot decides to place, so he places the top card
        //In the context of a game it would be a misplay to place a top hand card, which would result you in lying where there's no need
        //Based on optimistic algorithm the bot would do the safest play - play truthully if it can
        Assert.AreEqual("Heart 7", hand.deckCards[hand.deckCards.Count-1].ToString());
    }
}
