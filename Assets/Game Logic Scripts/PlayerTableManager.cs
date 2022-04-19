
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTableManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> cardModels = new List<GameObject>();

    [SerializeField]
    GameObject deckModel;

    [SerializeField]
    GameObject userHandUI;

    UserDeckUI handUI;

    public int deckDistance = 3;

    GameObject tableDeckObject;
    string tableDeckName = "Table Deck";


    List<Player> playerList = new List<Player>();
    List<GameObject> playerDeckObjects = new List<GameObject>();
    
    int startIndex =0;
    private Deck tableDeck;

    public float botTurnTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InitializeTable(4);
        InputManager.OnClick += HandleClick;   
    }

    //add difficulty && refactor xd
    public void InitializeTable(int players)
    {
        if(cardModels.Count < players)
        {
            Debug.LogError("Please add more card models to the table to start a game. There must be more cards than players to start a game");
            return;
        }
        tableDeckObject = Instantiate(deckModel);
        tableDeckObject.name = tableDeckName;
        //initialize deck
        tableDeck = new Deck(cardModels);
        tableDeck.ShuffleDeck();
        List<Deck> playerDecks = Deck.SplitDeck(tableDeck, players);

        //create players
        for (int i=0; i < players; i++)
        {
            playerList.Add(new Player());
            playerList[i].hand = playerDecks[i];
            
            playerDeckObjects.Add(Instantiate(deckModel, SpawnCoordinates.GetSpawnCoordinates(players)[i] * deckDistance, Quaternion.identity));
            playerDeckObjects[i].name = i.ToString();
            playerDeckObjects[i].transform.position = new Vector3(playerDeckObjects[i].transform.position.x, playerDeckObjects[i].transform.position.y, 0.5f);
        }
        //add event subscribers
        for (int i = 0; i < players; i++)
        {
            int temp_i = i;
            //on Turn end: gray out, pass turn to the player to the left 
            playerList[i].OnTurnEnd.AddListener(() => {
                playerDeckObjects[temp_i].GetComponent<Renderer>().material.color = Color.gray;
                playerList[(temp_i+1)%i].StartTurn();
            });

            // OnTurnStart behaviour for player: green in, wait for place card, place card, end turn
            if(i==0)
            {
                playerList[i].OnStartTurn.AddListener(() =>
                {
                    playerDeckObjects[temp_i].GetComponent<Renderer>().material.color = Color.green;
                    Debug.Log(playerList[temp_i].hand.ToString());
                });
                continue;
            }
            //OnTurnStart behaviour for bot: green in, place card, end turn
            playerList[i].OnStartTurn.AddListener(() =>
            {
                playerDeckObjects[temp_i].GetComponent<Renderer>().material.color = Color.green;
                StartCoroutine(PlaceCard(temp_i, playerDecks[temp_i].deckCards.Count-1, botTurnTime));
            });
        }
        userHandUI = Instantiate(userHandUI);
        handUI = userHandUI.GetComponent<UserDeckUI>();
        handUI.DisplayDeck(playerDecks[0]);

        //determine what player starts the game
        startIndex = Random.Range(0, players);
        Debug.Log(startIndex);
        playerList[startIndex].StartTurn();
    }


    private void HandleClick(object sender, GameObjectEventArgs e)
    {
        
        switch (playerList[0].turnState)
        {
            case TurnState.NotMyTurn:
                Debug.Log("Not your turn");
                break;
            default:
                int objectIndex = playerList[0].hand.FindIndex(e.go.name);
                if (objectIndex < 0)
                {
                    Debug.Log("No such card");
                    return;
                }
                StartCoroutine(PlaceCard(0, objectIndex, 0f));
                break;
        }
    }

    //refactor
    private IEnumerator PlaceCard(int player, int index, float delay)
    {
        if (playerList[player].hand.deckCards.Count == 1)
        {
            Debug.Log("Won");
            yield return null;
        }
        yield return new WaitForSeconds(delay);

        tableDeck.Push(playerList[player].hand.RemoveAt(index));
        foreach(Transform child in this.transform)
            Destroy(child.gameObject);
        //move this
        GameObject card = Instantiate(tableDeck.deckCards[tableDeck.deckCards.Count - 1].cardModel);
        card.transform.parent = this.transform;
        card.transform.localScale = SpawnCoordinates.CardScale(20);
        card.transform.Rotate(Vector3.left, 90f);
        playerList[player].EndTurn();
        if (player == 0)
        {
            handUI.DisplayDeck(playerList[0].hand);
        }
            
    }
}
