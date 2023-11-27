using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInputs;
using System;

public class MoveBehaviour : MonoBehaviour
{
    private GameInput _inputs;
    
    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();
    }

    private void Pick_Performed(InputAction.CallbackContext obj)
    {
        Debug.Log("pick");
    }

    // Start is called before the first frame update
    void Start()
    {
        _inputs.MainPlayer.PickWeapon.performed += Pick_Performed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
