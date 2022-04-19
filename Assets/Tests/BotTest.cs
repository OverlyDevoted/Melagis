using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BotTest
{
    List<GameObject> idealCards = new List<GameObject> {
            new GameObject("PlayingCards_7Heart"),
            new GameObject("PlayingCards_2Spade"),
            new GameObject("PlayingCards_AHeart"),
            new GameObject("PlayingCards_JClub"),
            new GameObject("PlayingCards_7Spade"),
            new GameObject("PlayingCards_10Diamond")};
    List<GameObject> badCards = new List<GameObject> {
            new GameObject("PlayingCards_7Heart"),
            new GameObject("PlayingCards_2Spade"),
            new GameObject("PlayingCards_JClub"),
            new GameObject("PlayingCards_7Spade"),
            new GameObject("PlayingCards_10Diamond")};

    // Test which calculates which card to place based on optimistic algorithm
    [Test]
    public void CheckOptimisticBotAlgorithmDecisionWhenHasOption()
    {
        //bot hand
        Deck hand = new Deck(idealCards);
        
        Card topDeck = new Card(new GameObject("PlayingCards_5Heart"));

        OptimisticBotAlgorithm algorithm = new OptimisticBotAlgorithm();
        Card resultCard = algorithm.CalculateMove(hand, topDeck);

        //currently there's no algorithm that count what bot decides to place, so he places the top card
        //In the context of a game it would be a misplay to place a top hand card, which would result you in lying where there's no need
        //Based on optimistic algorithm the bot would do the safest play - play truthully if it can
        Assert.AreEqual("Spade 7", resultCard.ToString());
    }
    [Test]
    public void CheckOptimisticBotAlgorithmDecisionWhenDoesNotHaveOption()
    {
        //bot hand
        Deck hand = new Deck(badCards);

        Card topDeck = new Card(new GameObject("PlayingCards_AHeart"));

        OptimisticBotAlgorithm algorithm = new OptimisticBotAlgorithm();
        Card resultCard = algorithm.CalculateMove(hand, topDeck);

        //currently there's no algorithm that count what bot decides to place, so he places the top card
        //In the context of a game it would be a misplay to place a top hand card, which would result you in lying where there's no need
        //Based on optimistic algorithm the bot would do the safest play - play truthully if it can, if it can't it places the top card of his hand
        Assert.AreEqual("Diamond 10", resultCard.ToString());
    }
}
