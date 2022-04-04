using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class OptimisticBotAlgorithm : IBot
{
    public Card CalculateMove(Deck hand, Card topDeck)
    {
        int topDeckValue = topDeck.value;
        int cur = 14;
        int index = -1;
        for (int i = 0; i < hand.deckCards.Count; i++)
        {
            if(hand.deckCards[i].value > topDeckValue && hand.deckCards[i].value <= cur)
            {
                cur = hand.deckCards[i].value;
                index = i;
            }
        }
        if(index != -1)
        return hand.deckCards[index];
        return hand.deckCards[hand.deckCards.Count-1];
    }
}
