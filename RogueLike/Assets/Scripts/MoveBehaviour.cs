using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls = null;
    private InputAction _up = null;
    private void Awake()
    {
        var gameplayMap = playerControls.FindActionMap("MainPlayer");
        _up = gameplayMap.FindAction("Up");
        _up.performed += Move();

    }
    void Move(InputAction.CallbackContext context)
    {
        if(context.ReadValue()  == _up)
        {
            Debug.Log("UP");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
