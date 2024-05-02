using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmallMove : MonoBehaviour
{
    //VARIABLES
    //Move
    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private float _moveAxis;
<<<<<<< Updated upstream:Assets/Scripts/small/small move.cs
    public int direction = 1;
    
=======

    //Jump
    [SerializeField] private float _jumpForce = 10000f;
    private int _maxJumps = 1;

    private int _actualJumps = 0;

    //Dash
    public int direction = 1;
    public float dashDistance = 5f;
    public float dashSpeed = 10f;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

>>>>>>> Stashed changes:Assets/Scripts/CharacterMove.cs
    void FixedUpdate()
    {
        transform.Translate(new Vector3(1, 0, 0) * (_moveAxis * _moveSpeed * Time.deltaTime));
    }

<<<<<<< Updated upstream:Assets/Scripts/small/small move.cs
    public void HandleSmallMove(InputAction.CallbackContext moveInput)
=======
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _actualJumps = 0;
        }
    }


    // Input Actions
    //Move
    public void HandleMove(InputAction.CallbackContext moveInput)
>>>>>>> Stashed changes:Assets/Scripts/CharacterMove.cs
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
<<<<<<< Updated upstream:Assets/Scripts/small/small move.cs
    }
=======

    }

    //Jump
    public void HandleJump(InputAction.CallbackContext jumpInput)
    {
        if (jumpInput.performed && _actualJumps < _maxJumps)
        {
            Debug.Log("Jumping");
            _rigidbody.AddForce(transform.up * _jumpForce);
            _actualJumps += 1;
        }
    }
    
    //Dash
    public void HandleDash(InputAction.CallbackContext dashInput)
    {
        if (dashInput.performed)
        {
            StartCoroutine(PerformDash());
        }
    }

    IEnumerator PerformDash()
    {
        Vector3 startPosition = transform.position;


        //direction = characterMoveScript.direction;
        Vector3 endPosition = transform.position + transform.right * dashDistance * direction;


        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, dashSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = endPosition;
    }
>>>>>>> Stashed changes:Assets/Scripts/CharacterMove.cs
}