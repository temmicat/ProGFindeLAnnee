using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class dashanddimensionswap : MonoBehaviour
{
    private bool currentDimension = false; // false = etat 1  :  true = etat 2
    public float dashDistance = 5f; // Distance to dash
    public float dashSpeed = 10f; // Speed of dash
    private bool isDashing = false; // Flag to check if character is dashing
	private CharacterMove characterMoveScript;
	private int direction;

	void Start()
	{
		characterMoveScript = GetComponent<CharacterMove>();
		direction = characterMoveScript.direction;
	}

    // Rename the coroutine to avoid conflict
    IEnumerator PerformDash()
    {
        isDashing = true;

        // Store current position
        Vector3 startPosition = transform.position;

        // Calculate dash end position
		direction = characterMoveScript.direction;
        Vector3 endPosition = transform.position + transform.right * dashDistance * direction;

        // Move towards end position at dash speed
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, dashSpeed * Time.deltaTime);
            yield return null;
        }

        // Ensure we end up exactly at the dash end position
        transform.position = endPosition;

        isDashing = false;
    }

    // Use this method as the input action callback for Dash
    public void HandleDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(PerformDash());
        }
    }

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
}
