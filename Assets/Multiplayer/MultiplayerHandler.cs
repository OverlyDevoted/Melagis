using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
public class MultiplayerHandler : MonoBehaviour
{
    public static event EventHandler OnConnectionError;
    public static event EventHandler OnConnecting;
    public static event EventHandler OnConnected;
    private delegate void VoidDelegate();
    private VoidDelegate OnToDo;
    WebState webState;
    public Method method = new Method();
    public Client client = new Client();

    public enum WebState
    {
        TYPE,
        CLASS
    }
    WebSocket ws;

    private void Start()
    {
        webState = WebState.TYPE;
        ConnectServer();
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
        OnConnecting?.Invoke(this,EventArgs.Empty);
        if (ws != null)
            ws.Close();
        ws = new WebSocket("ws://127.0.01:9090");
        
        
        
        ws.OnClose += (sender, e) =>
        {
            OnToDo += () => { OnConnectionError?.Invoke(this, EventArgs.Empty); };
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
                            Debug.Log(client.clientID);
                            break;
                    }
                    method = null;
                    webState = WebState.TYPE;
                    break;
            }
        };
        ws.Connect();
        if (!ws.IsAlive)
        {
            OnConnectionError?.Invoke(this, EventArgs.Empty);
            return; 
        }
        OnConnected?.Invoke(this, EventArgs.Empty);
    }

    

}


