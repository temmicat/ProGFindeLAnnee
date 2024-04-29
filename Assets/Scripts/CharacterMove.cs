using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _moveAxis;
    [SerializeField] private float _jumpForce = 1f;
    public int direction = 1;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(1, 0, 0) * (_moveAxis * _moveSpeed * Time.deltaTime));
    }

    public void HandleMove(InputAction.CallbackContext moveInput)
    {
        _moveAxis = moveInput.ReadValue<float>();
        if (_moveAxis > 0)
        {
            direction = 1;
        }
        if (_moveAxis < 0)
        {
            direction = -1;
        }
        
    }

    public void HandleJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed)
        {
            Debug.Log("Jumping");
            _rigidbody.AddForce(transform.up * _jumpForce);
        }
    }
}
