using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    private void Awake()
    {
        MultiplayerHandler.OnServerMessage += uiManager.AddMessageToLog;
    }

}
