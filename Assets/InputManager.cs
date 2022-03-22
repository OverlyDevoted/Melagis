using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    InputConfiguration inputs;
    GameObject selectedObject;
    private void Awake()
    {
        inputs = new InputConfiguration();
        inputs.Enable();
        inputs.Main.Mouseclicks.performed += CheckForObject;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CheckForObject(InputAction.CallbackContext obj)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputs.Main.Mouseposition.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
        }
     }
}
