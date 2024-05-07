using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class smallactivate : MonoBehaviour
{
    public bool isActivating = false;
    public void HandleActivateSmall(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isActivating = true;
        }
        else if(context.canceled)
        {
            isActivating = false;
        }
    }
}
