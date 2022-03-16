using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public List<UIElement> elements;
    private void Awake()
    {
        int elementsLenght = elements.Count;
        for (int i = 0; i < elementsLenght; i++)
        {
            for (int j = 0; j < elementsLenght; j++)
            {
                if(i!=j)
                    elements[i].OnEnable.AddListener(elements[j].Disable);
            }
        }
    }
    public void EnableElement(int index)
    {
        if(index<elements.Count || index < 0)
        {
            elements[index].Enable();
        }
        else
        {
            Debug.LogWarning("Trying to access non existent UI element");
        }
    }
}
