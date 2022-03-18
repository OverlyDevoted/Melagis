using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] List<GameObject> cardModels;
    List<GameObject> cards;
    
    // Start is called before the first frame update
    void Start()
    {
        cards = new List<GameObject>();
        GenerateDeck();
    }
    public void GenerateDeck()
    {
        Debug.Log("Generate");
    }
    public void ShuffleDeck()
    {
        Debug.Log("Shuffle");
    }
    public void SetDeck(List<GameObject> newCards)
    {
        CopyTo(newCards, cards);
    }
    private void CopyTo(List<GameObject> from, List<GameObject> to)
    {
        foreach (GameObject card in from)
        {
            to.Add(card);
        }
    }
    public void PrintDeck()
    {
        foreach (GameObject t in cards)
            Debug.Log(t.name);
    }
}
