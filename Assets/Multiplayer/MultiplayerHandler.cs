using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;
using System;
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
                            OnToDo += () => { OnServerMessage?.Invoke(this, new OnServerMessageEventArgs("Successfully connected to the server. Your ID is " + client.clientID)); };
                            break;

                        case "create":
                            game = JsonUtility.FromJson<Game>(e.Data);
                            SendJoinLobby(game.gameID);
                            break;
                        case "join":
                            game = JsonUtility.FromJson<Game>(e.Data);
                            OnToDo += () => { 
                                OnJoinedGame.Invoke();
                                OnServerMessage?.Invoke(this, new OnServerMessageEventArgs("Successfully joined a lobby. Lobby ID is <color=green>" + game.gameID + "</color>"
                                    +"\n<i>For other players to join the lobby send them the lobby ID</i>"));
                                if (game.clients.Length < 2)
                                    return;
                                OnServerMessage?.Invoke(this, new OnServerMessageEventArgs("Other players in the lobby:\n"));
                                foreach (Client c in game.clients)
                                {
                                    if(c.clientID != client.clientID)
                                    {
                                        OnServerMessage?.Invoke(this, new OnServerMessageEventArgs(c.clientID + " with prio: " + client.prio));
                                    }
                                }
                            };
                            break;
                        case "playerJoined":
                            Game temp = JsonUtility.FromJson<Game>(e.Data);
                            game.clients = temp.clients;
                            OnToDo += () =>
                            {
                                foreach (Client c in game.clients)
                                {
                                    if (c.clientID != client.clientID)
                                    {
                                        OnServerMessage?.Invoke(this, new OnServerMessageEventArgs("Player " + c.clientID + " joined with prio: " + c.prio));
                                    }
                                }
                            };
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
        Debug.Log(gameID);
        ws.Send("{\"method\":\"join\"," +
            "\"gameID\":\""+gameID+"\"}");
    }
    private void ResetData()
    {
        client = new Client();
        game = new Game();
    }
    public void LeaveLobby()
    {
        game = new Game();
        OnServerMessage?.Invoke(this, new OnServerMessageEventArgs("Left the lobby"));
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

