using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_InputField serverLog;

   
    private void Start()
    {
        serverLog.text = "";
    }
   
    public void AddMessageToLog(object obj, OnServerMessageEventArgs e)
    {
        serverLog.text += e.message + "\n";
    }
    public void ClearServerLog()
    {
        serverLog.text = "";
    }
}

