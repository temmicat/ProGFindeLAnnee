using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private int MaxJump = 2;
    [SerializeField] private echelle codeEchelle;
    private int CurrentJumpCount = 0;
    private Rigidbody _rigidbody;

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

    public void HandleSmallJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            if (CurrentJumpCount < MaxJump)
            {
                if (codeEchelle.usingLadder == false)
                {
                    _rigidbody.AddForce(transform.up * _jumpForce);
                    CurrentJumpCount += 1;
                }
                
            }
        }
    }
}