using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int value = 0;
    bool isMain = false;
    private void Awake()
    {
        var managers = FindObjectsOfType(typeof(GameManager));
        if (managers.Length != 1)
        {
            if (!isMain)
                Destroy(this.gameObject);
        }
        isMain = true;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Increment()
    {
        value++;
    }
}
