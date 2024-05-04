using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private echelle codeEchelle;
    
    private float _moveAxis;
    public int direction = 1;
    
    void FixedUpdate()
    {
        if (codeEchelle.usingLadder == false)
        {
            transform.Translate(new Vector3(1, 0, 0) * (_moveAxis * _moveSpeed * Time.deltaTime));
        }
    }

    public void HandleSmallMove(InputAction.CallbackContext moveInput)
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
}