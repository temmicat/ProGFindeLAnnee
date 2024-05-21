using UnityEngine;
using UnityEngine.InputSystem;

public class cablesmall : MonoBehaviour
{
    public float taillecable = 4f;
    public float offset = 0.6f;
    public float climbSpeed = 10f;
    private bool canClimb = false;
    private bool canGoDown = false;
    private bool isClimbing = false;
    private bool isGoingDown = false;
    private Vector3 targetPosition;

    [SerializeField] private Collider playerCollider;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("cable"))
        {
            if (transform.position.y <= other.gameObject.transform.position.y)
            {
                canClimb = true;
                canGoDown = false;
            }
            if (transform.position.y > other.gameObject.transform.position.y)
            {
                canGoDown = true;
                canClimb = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cable"))
        {
            canClimb = false;
            canGoDown = false;
        }
    }

    public void HandleClimbcable(InputAction.CallbackContext context)
    {
        if (context.performed && canClimb)
        {
            targetPosition = transform.position + transform.up * (taillecable + offset);
            isClimbing = true;
            playerCollider.isTrigger = true;
        }
        else if (context.canceled && playerCollider != null)
        {
            isClimbing = false;
            playerCollider.isTrigger = false;
        }
    }

    public void HandleGoDowncable(InputAction.CallbackContext context)
    {
        if (context.performed && canGoDown)
        {
            targetPosition = transform.position + transform.up * (taillecable - offset) * -1;
            isGoingDown = true;
            playerCollider.isTrigger = true;
        }
        else
        {
            isGoingDown = false;
            playerCollider.isTrigger = false;
        }
    }

    private void Update()
    {
        if (isClimbing || isGoingDown)
        {
            float step = climbSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isClimbing = false;
                isGoingDown = false;
                playerCollider.isTrigger = false;
            }
        }
    }
}
