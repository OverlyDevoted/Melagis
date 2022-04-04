using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTableManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> cardModels = new List<GameObject>();

    [SerializeField]
    GameObject deckModel;


    List<Player> playerList = new List<Player>();
    List<GameObject> playerDeckObjects = new List<GameObject>();

    int userIndex =0;
    private Deck tableDeck; 
    // Start is called before the first frame update
    void Start()
    {
        InitializeTable(4);
    }

    //add difficulty
    public void InitializeTable(int players)
    {
        if(cardModels.Count < players)
        {
            Debug.LogError("Please add more card models to the table to start a game. There must be more cards than players to start a game");
            return;
        }
        //initialize deck
        tableDeck = new Deck(cardModels);
        tableDeck.ShuffleDeck();

        //create players
        for(int i=0; i < players; i++)
        {
            playerList.Add(new Player());
            playerDeckObjects.Add(Instantiate(deckModel));
            playerDeckObjects[i].name = i.ToString();
        }
        
        //determine user index - turn order
        userIndex = Random.Range(0,players);

        List <Deck> playerDecks = Deck.SplitDeck(tableDeck, players);
        for(int i = 0; i < players; i++)
        {
            playerList[i].hand = playerDecks[i];
            Debug.Log(playerList[i].hand.ToString());
        }

    }
}
