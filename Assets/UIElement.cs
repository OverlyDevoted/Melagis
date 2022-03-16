using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIElement : MonoBehaviour
{
    public UnityEvent OnEnable;
    public void Enable()
    {
        Debug.Log("Enable me " + gameObject.name);
        this.gameObject.SetActive(true);
        OnEnable.Invoke();
    }
    public void Disable()
    {
        Debug.Log("Disable me " + gameObject.name);
        this.gameObject.SetActive(false);
    }
}
