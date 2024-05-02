using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class dashanddimensionswap : MonoBehaviour
{
    //private bool currentDimension = false; // false = etat 1  :  true = etat 2
    public float dashDistance = 5f; // Distance du dash
    public float dashSpeed = 10f; // vitesse du dash
	private CharacterMove characterMoveScript;
	private int direction;

	void Start()
	{
		characterMoveScript = GetComponent<CharacterMove>();
		direction = characterMoveScript.direction;
	}

    public void HandleDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(PerformDash());
        }
    }
    IEnumerator PerformDash()
    {
        Vector3 startPosition = transform.position;

        
        direction = characterMoveScript.direction;
        Vector3 endPosition = transform.position + transform.right * dashDistance * direction;

        
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, dashSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = endPosition;
    }
}
/*
    public void HandleDimensionSwap(InputAction.CallbackContext dimensionSwap)
    {
        if (dimensionSwap.performed)
        {
            if (currentDimension)
            {
                Debug.Log("dimension swap");
                transform.Rotate(0, 90, 0);
                currentDimension = false;
            }
            else
            {
                Debug.Log("dimension swap");
                transform.Rotate(0, -90, 0);
                currentDimension = true;
            }
        }
    }

*/