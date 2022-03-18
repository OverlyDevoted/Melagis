using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UIElement : MonoBehaviour
{
    public UnityEvent OnEnable;
    public void Enable()
    {
        this.gameObject.SetActive(true);
        OnEnable.Invoke();
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
