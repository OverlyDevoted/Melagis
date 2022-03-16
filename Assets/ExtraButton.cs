using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
[System.Serializable]
public class StringEvent : UnityEvent<string> { }
public class ExtraButton : MonoBehaviour
{
    public TMP_InputField input;
    public StringEvent OnClick;
    public void Click()
    {
        OnClick.Invoke(input.text);
    }
}
