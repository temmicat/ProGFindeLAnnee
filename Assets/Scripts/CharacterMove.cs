using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMove : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private float _moveAxis;
    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(1, 0, 0) * (_moveAxis * _moveSpeed * Time.deltaTime));
    }

    public void HandleMove(InputAction.CallbackContext moveInput)
    {
        _moveAxis = moveInput.ReadValue<float>();
    }

    public void HandleJump(InputAction.CallbackContext jumpInput)
    {
        
    }
}
