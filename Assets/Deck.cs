using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<GameObject> cardModels;
    List<GameObject> cards;
    public float distBetweenCards = -0.001f;
    public float startingZ = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        cards = new List<GameObject>();
        GenerateDeck();
    }
    public void GenerateDeck()
    {
        float curZ = startingZ;
        foreach(GameObject card in cardModels)
        {
            //turn this into prefab that is has all of these values instantiated
            GameObject newCard = new GameObject();
            newCard.transform.parent = gameObject.transform;
            Instantiate(card).transform.parent = newCard.transform;
            newCard.transform.localScale = new Vector3(20f, 20f, 20f);
            newCard.transform.Rotate(new Vector3(-90f, 0f));
            newCard.transform.position = new Vector3(newCard.transform.position.x, newCard.transform.position.y, curZ);
            curZ += distBetweenCards;
            newCard.AddComponent<Card>();
            foreach(Transform c in newCard.transform)
            {
                newCard.GetComponent<Card>().SetCardModel(c.gameObject);
            }
            cards.Add(newCard);
        }
    }
    public void ShuffleDeck()
    {
        List<GameObject> tempDeck = new List<GameObject>();
        CopyTo(cards, tempDeck);
        float curZ = startingZ;
        int totalCards = tempDeck.Count;
        for (int i=0;i<totalCards;i++)
        {
            int randomIndex = Random.Range(0, tempDeck.Count);
            tempDeck[randomIndex].transform.position = new Vector3(tempDeck[randomIndex].transform.position.x, tempDeck[randomIndex].transform.position.y, curZ);
            curZ += distBetweenCards;
            tempDeck.RemoveAt(randomIndex);
        }
    }

    private void CopyTo(List<GameObject> from, List<GameObject> to)
    {
        foreach (GameObject card in from)
        {
            to.Add(card);
        }
    }
    public void PrintDeck(List<GameObject> cards)
    {
        foreach (GameObject t in cards)
            Debug.Log(t.name);
    }
}
