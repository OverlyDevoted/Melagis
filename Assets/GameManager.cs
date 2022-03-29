using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public UnityEvent OnAwake;
    public UIManager uiManager;
    private void Awake()
    {
        OnAwake.Invoke();  
        
    }
}
