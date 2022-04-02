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
        
    }
    public void ShuffleDeck()
    {

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
