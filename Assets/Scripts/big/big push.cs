using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bigpush : MonoBehaviour
{
	private bool CanPush = false;
	private GameObject target = null;
	public bool isPushing = false;

	private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("block"))
        {
			CanPush = true;
			target = other.gameObject;
        }
    }
	private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("block"))
        {
			CanPush = false;
			target = null;
        }
    }
	
	public void HandlePush(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (CanPush == true)
            {
				target.transform.parent = this.transform;
				isPushing = true;
            }
            else
            {
	            isPushing = false;
            }
        }
		else if (context.canceled)
		{
			CanPush = false;
			if (target != null)
			{
				target.transform.parent = null;
			}
			isPushing = false;
		}
    }
}
