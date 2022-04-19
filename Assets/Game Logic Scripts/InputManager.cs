using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  
using System;

public class InputManager : MonoBehaviour
{
    //public static InputManager instance;
    InputConfiguration inputs;
    GameObject selectedObject;
    public static event EventHandler<GameObjectEventArgs> OnClick;
    //implement an event that triggers and passes in the object as a parameter
    private void Awake()
    {
        inputs = new InputConfiguration();
        //instance = this;
        inputs.Enable();
        inputs.Main.Mouseclicks.performed += CheckForObject;
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
            OnClick?.Invoke(this, new GameObjectEventArgs(hit.collider.gameObject));
        }
     }
}
public class GameObjectEventArgs: EventArgs
{
    public GameObject go { get; private set; }
    public GameObjectEventArgs(GameObject go)
    {
        this.go = go; 
    }
}