using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    private void Awake()
    {
        MultiplayerHandler.OnConnecting += uiManager.SetConnecting;
        MultiplayerHandler.OnConnected += uiManager.SetMainMenu;
        MultiplayerHandler.OnConnectionError += uiManager.SetRetry;
    }

}
