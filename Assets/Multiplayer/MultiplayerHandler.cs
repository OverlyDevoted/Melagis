using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using System;
/*
 Try adding a function that adds a delegate to a method name. 
So whenever the server send a certain method it executes the said delegate. Somewhat of a dictionary of functions 
It would make it so that the multiplayer handler performs less logic handling and it ill play more of a intermediary role
 */

[Serializable]
public class MultiplayerHandler : MonoBehaviour
{
    public UnityEvent OnConnectionError;
    public UnityEvent OnConnecting;
    public UnityEvent OnConnected;
    public UnityEvent OnJoinedGame;
    public ExtraButton joinButton;
    public static event EventHandler<OnServerMessageEventArgs> OnServerMessage;

    public delegate void VoidDelegate();
    private VoidDelegate OnToDo;
    
    WebState webState;
    
    public Method method = new Method();
    public Client client = new Client();
    public Game game = new Game();
    public enum WebState
    {
        TYPE,
        CLASS
    }
    WebSocket ws;

    private void Start()
    {
        OnConnectionError.AddListener(ResetData);
        webState = WebState.TYPE;
        ConnectServer();
        joinButton.OnClick.AddListener(SendJoinLobby);
    }
    private void Update()
    {
        if(OnToDo != null)
        {
            OnToDo();
            OnToDo = null;
        }
    }
    
    public void ConnectServer()
    {
        OnConnecting.Invoke();
        if (ws != null)
            ws.Close();
        ws = new WebSocket("ws://127.0.01:9090");
        
        
        
        ws.OnClose += (sender, e) =>
        {
            OnToDo += () => { OnConnectionError.Invoke(); };
            Debug.Log("Lost connection");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log(e.Data);
            switch(webState)
            {
                case WebState.TYPE:
                    method = JsonUtility.FromJson<Method>(e.Data);
                    webState = WebState.CLASS;
                    break;
                case WebState.CLASS:
                    switch (method.name)
                    {
                        case "connect":

                            client = JsonUtility.FromJson<Client>(e.Data);
                            OnToDo += () => { AddMessage("Successfully connected to the server. Your ID is " + client.clientID); };
                            break;

                        case "create":
                            game = JsonUtility.FromJson<Game>(e.Data);
                            SendJoinLobby(game.gameID);
                            break;
                        case "join":
                            game = JsonUtility.FromJson<Game>(e.Data);
                            OnToDo += () =>
                            {
                                OnJoinedGame.Invoke();
                                AddMessage("Successfully joined a lobby. Lobby ID is <color=green>" + game.gameID + "</color>"
                                    + "\n<i>For other players to join the lobby send them the lobby ID</i>");
                                if (game.clients.Count < 2)
                                    return;
                                AddMessage("Other players in the lobby:");
                                foreach (Client c in game.clients)
                                {
                                    if (c.clientID != client.clientID)
                                    {
                                        AddMessage(c.clientID + " with prio: " + c.prio);
                                        continue;
                                    }
                                    client.prio = c.prio;
                                }
                            };
                            break;
                        case "playerJoined":
                            {
                                Client temp = JsonUtility.FromJson<Client>(e.Data);
                                temp.prio = game.clients.Count;
                                temp.ready = false;
                                game.clients.Add(temp);
                                OnToDo += () =>
                                {
                                    AddMessage("Player " + temp.clientID + " has joined with prio " + temp.prio);
                                };
                            }
                            break;
                        case "playerDisconnected":
                            {
                                Client temp = JsonUtility.FromJson<Client>(e.Data);
                                if (temp.prio != client.prio)
                                {
                                    OnToDo += () =>
                                    {
                                        client.prio = temp.prio;
                                        AddMessage("Your new prio is: " + client.prio);
                                        game.ChangePrio(client.clientID, client.prio);
                                    };
                                }
                                game.RemoveClient(temp.clientID);
                                AddMessage("Player " + temp.clientID + " has disconnected");
                            }
                            break;
                        case "ready":
                            {
                                Client temp = JsonUtility.FromJson<Client>(e.Data);
                                bool isReady = game.ReadyClient(temp.clientID);
                                OnToDo += () =>
                                {
                                    string answer = "";
                                    if (isReady)
                                        answer = "ready";
                                    else
                                        answer = " not ready";
                                    AddMessage("Player "+temp.clientID + " is " + answer);
                                };
                            }
                            break;
                        case "error":
                            {
                                Error error = JsonUtility.FromJson<Error>(e.Data);
                                OnToDo += () =>
                                {
                                    AddMessage(error.message);
                                };
                            }
                            break;

                    }
                    method = null;
                    webState = WebState.TYPE;
                    break;
            }
        };
        ws.Connect();
        OnConnected.Invoke();
        if (!ws.IsAlive)
        {
            OnConnectionError.Invoke();
            return; 
        }
    }

    public void SendCreateLobby()
    {
        ws.Send("{\"method\":\"create\"}");
    }
    public void SendJoinLobby(string gameID)
    {
        ws.Send("{\"method\":\"join\"," +
            "\"gameID\":\""+gameID+"\"}");
    }
    public void SendDisconnectLobby()
    {
        ws.Send("{\"method\":\"disconnect\"}");
    }
    public void SendReady()
    {
        ws.Send("{\"method\":\"ready\"}");
    }
    public void Ready()
    {
        AddMessage("You ready dawg");
        client.ready = !client.ready;
        SendReady();
    }
    private void ResetData()
    {
        client = new Client();
        game = new Game();
    }
    public void LeaveLobby()
    {
        game = new Game();
        AddMessage("Left the lobby");
        SendDisconnectLobby();
    }
    public void AddMessage(string message)
    {
        OnServerMessage?.Invoke(this, new OnServerMessageEventArgs(message));
    }
}
public class OnServerMessageEventArgs : EventArgs
{
    public string message;
    public OnServerMessageEventArgs(string message)
    {
        this.message = message;
    }
}

