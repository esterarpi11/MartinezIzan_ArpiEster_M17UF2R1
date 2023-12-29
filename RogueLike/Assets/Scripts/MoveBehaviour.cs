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
        _inputs.MainPlayer.Movement.performed += Move_Performed;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        if (hor != 0 || ver != 0)
        {
            _animator.SetFloat("horizontal", hor);
            _animator.SetFloat("vertical", ver);
            _animator.SetFloat("speed", 1);
        }
        else
        {
            _animator.SetFloat("speed", 0);
        }
    }
    private void Move_Performed(InputAction.CallbackContext obj)
    {
        _rigidbody.velocity = obj.ReadValue<Vector2>() * _speed;
    }

}
