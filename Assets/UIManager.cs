using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UIManager : MonoBehaviour
{
    public List<GameObject> uiElements;
    
    private event EventHandler<OnChangedEventArgs> OnChanged;
    public class OnChangedEventArgs : EventArgs
    {
        public GameObject gameObject;
        public OnChangedEventArgs(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
    }
    public void EnableUI(GameObject ui)
    {
        OnChanged?.Invoke(this, new OnChangedEventArgs(ui));
    }
    private void Awake()
    {
        OnChanged += DisableIrreleventUI;
    }
    private void Start()
    {
        
    }
    private void DisableIrreleventUI(object obj, OnChangedEventArgs e)
    {
        int uiLenght = uiElements.Count;
        for(int i=0;i<uiLenght;i++)
        {
            if(uiElements[i] == e.gameObject)
            {
                uiElements[i].SetActive(true);
                continue;
            }
            uiElements[i].SetActive(false);
        }
    }
    public void SetConnecting(object obj, EventArgs e)
    {
        EnableUI(uiElements[0]);
    }

    public void SetRetry(object obj, EventArgs e)
    {
        EnableUI(uiElements[1]);
    }

    public void SetMainMenu(object obj, EventArgs e)
    {
        EnableUI(uiElements[2]);
    }
}

public enum UIState
{
    Connecting,
    Error,
    Connected,
    InGame
}