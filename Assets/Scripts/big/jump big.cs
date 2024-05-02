using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BigJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void HandleBigJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            Debug.Log("Big Jumping");
            _rigidbody.AddForce(transform.up * _jumpForce);
        }
    }
}