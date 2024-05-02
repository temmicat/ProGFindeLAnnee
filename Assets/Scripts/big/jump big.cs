using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BigJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private int MaxJump = 2;
    private int CurrentJumpCount = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            CurrentJumpCount = 0;
        }
    }

    public void HandleBigJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            if (CurrentJumpCount < MaxJump)
            {
                Debug.Log("Big Jumping");
                _rigidbody.AddForce(transform.up * _jumpForce);
                CurrentJumpCount += 1;
            }
        }
    }
}