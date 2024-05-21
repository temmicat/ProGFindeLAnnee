using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BigJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private int MaxJump = 1;
    private int CurrentJumpCount = 0;
    private Rigidbody _rigidbody;
    [SerializeField] public bigpush target;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Plateforme"))
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
                if (target.isPushing == false)
                {
                    _rigidbody.AddForce(transform.up * _jumpForce);
                    CurrentJumpCount += 1;
                }
            }
        }
    }
}