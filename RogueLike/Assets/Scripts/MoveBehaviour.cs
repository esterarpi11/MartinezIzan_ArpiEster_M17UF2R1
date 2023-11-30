using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInputs;
using System;

public class MoveBehaviour : MonoBehaviour
{
    private GameInput _inputs;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float _speed= 5f;

    private void Awake()
    {
        _inputs = new GameInput();
        _inputs.MainPlayer.Enable();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _inputs.MainPlayer.PickWeapon.performed += Pick_Performed;

        _inputs.MainPlayer.Movement.performed += Move_Performed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Pick_Performed(InputAction.CallbackContext obj)
    {
        Debug.Log("pick");
    }
    private void Move_Performed(InputAction.CallbackContext obj)
    {
        _rigidbody.velocity = obj.ReadValue<Vector2>() * _speed;
    }

}
