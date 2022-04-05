using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assert.areEqual(expected:failo turinys, actual: ""

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FILE* fPointer;
        fPointer = fopen("NuskaitomasisFailas.txt");
        char[150] singleLine;

        while(!feof(fPointer))
        {
            fgets(singleLine, 150, fPointer);
            puts(singleLine);
        }
        fclose(fPointer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
