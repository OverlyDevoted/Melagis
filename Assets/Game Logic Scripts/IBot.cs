using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBot 
{
    public Card CalculateMove(Deck hand, Card topDeck);
}
