using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class echelle : MonoBehaviour
{
    public float tailleEchelle = 4f;

    public float offset = 0.6f;
    public float climbSpeed = 10f;
    private bool canClimb = false;
    private bool canGoDown = false;
    
    private Vector3 playerPosition;
    private Vector3 ladderPosition;

    public bool usingLadder = false;
    
    [SerializeField] private Collider playerCollider;
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Echelle"))
        {
            playerPosition = transform.position;
            ladderPosition = other.gameObject.transform.position;
            if (playerPosition.y < ladderPosition.y)
            {
                canClimb = true;
            }
            if (playerPosition.y > ladderPosition.y)
            {
                canGoDown = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Echelle"))
        {
            canClimb = false;
            canGoDown = false;
        }
    }
    public void HandleClimbEchelle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canClimb == true)
            {
                StartCoroutine(ClimbingEchelle());
            }
        }
    }
    
    public void HandleGoDownEchelle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (canGoDown == true)
            {
                StartCoroutine(GoingDownEchelle());
            }
        }
    }
    IEnumerator ClimbingEchelle()
    {
        Vector3 startPosition = transform.position;

        
        Vector3 endPosition = transform.position + transform.up * (tailleEchelle + offset);

        playerCollider.isTrigger = true;
        usingLadder = true;
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, climbSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = endPosition;
        playerCollider.isTrigger = false;
        usingLadder = false;
    }
    
    IEnumerator GoingDownEchelle()
    {
        Vector3 startPosition = transform.position;

        
        Vector3 endPosition = transform.position + transform.up * (tailleEchelle - offset) * -1;

        playerCollider.isTrigger = true;
        usingLadder = true;
        while (Vector3.Distance(transform.position, endPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, climbSpeed * Time.deltaTime);
            yield return null;
        }
        
        transform.position = endPosition;
        playerCollider.isTrigger = false;
        usingLadder = false;
    }
}
