using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDeckUI : MonoBehaviour
{
    public GameObject cardHolder;
    public float deckDistanceFromMiddle = 4f;
    public float cardDistance = 0.5f;
    public float zDiff = 0.1f;

    public void DisplayDeck(Deck deckToDisplay)
    {
        foreach(Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        if (deckToDisplay.deckCards.Count != 0)
        {
            Debug.Log(deckToDisplay.deckCards.Count);
            int length = deckToDisplay.deckCards.Count/2;
            if (deckToDisplay.deckCards.Count % 2 == 0)
            { 
                SpawnCard(deckToDisplay.deckCards[deckToDisplay.deckCards.Count-1], new Vector3(length * cardDistance, 0f - deckDistanceFromMiddle, length * zDiff));
                length--;
            }
            SpawnCard(deckToDisplay.deckCards[length], new Vector3(0f, 0f - deckDistanceFromMiddle));
            for (int i = 1; i <= length;i++)
            {
                SpawnCard(deckToDisplay.deckCards[length+i], new Vector3(i*cardDistance, 0f - deckDistanceFromMiddle, i * zDiff));
                SpawnCard(deckToDisplay.deckCards[length-i], new Vector3(-i*cardDistance, 0f - deckDistanceFromMiddle, -i * zDiff));
            }
            
        }
    }
    public void SpawnCard(Card card, Vector3 coordinates)
    {
        GameObject cardObj= Instantiate(card.cardModel, transform.parent);
        cardObj.transform.parent = this.transform;
        cardObj.transform.localScale = SpawnCoordinates.CardScale(20);
        cardObj.transform.Rotate(Vector3.left, 90f);

        GameObject cardHolderObj = Instantiate(cardHolder);
        cardHolderObj.name = card.ToString();
        cardHolderObj.transform.parent = cardObj.transform;        
        cardObj.transform.position = coordinates;
    }
}
