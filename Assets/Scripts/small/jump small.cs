using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void HandleSmallJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            Debug.Log("Small Jumping");
            _rigidbody.AddForce(transform.up * _jumpForce);
        }
    }
}