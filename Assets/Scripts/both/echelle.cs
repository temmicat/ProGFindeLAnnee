/*using System.Collections;
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
	private int direction;
    
    [SerializeField] private Collider playerCollider;
    [SerializeField] public bigpush target;
    
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Echelle"))
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
	    else if (context.canceled && playerCollider != null)
	    {
		    playerCollider.isTrigger = false;
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
        if(usingLadder == false)
		{
        	Vector3 startPosition = transform.position;
        	Vector3 endPosition = transform.position + transform.up * (tailleEchelle + offset);

        	playerCollider.isTrigger = true;

        	while (Vector3.Distance(transform.position, endPosition) > 0.2f)
        	{
				usingLadder = true;
            	transform.position = Vector3.MoveTowards(transform.position, endPosition, climbSpeed * Time.deltaTime);
            	yield return null;
        	}
			transform.position = endPosition;
        	playerCollider.isTrigger = false;
	        usingLadder = false;
        }

    }
    
    IEnumerator GoingDownEchelle()
    {
        if(usingLadder == false)
		{
        	Vector3 startPosition = transform.position;
        	Vector3 endPosition = transform.position + transform.up * (tailleEchelle - offset) * -1;

        	playerCollider.isTrigger = true;
        	while (Vector3.Distance(transform.position, endPosition) > 0.2f)
        	{
				usingLadder = true;
            	transform.position = Vector3.MoveTowards(transform.position, endPosition, climbSpeed * Time.deltaTime);
            	yield return null;
        	}
			transform.position = endPosition;
        	playerCollider.isTrigger = false;
			usingLadder = false;
        }
        
    }
}
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class echelle : MonoBehaviour
{
    public float tailleEchelle;
    public float offset = 0.6f;
    public float climbSpeed = 10f;
    private bool canClimb = false;
    private bool canGoDown = false;
    private bool isClimbing = false;
    private bool isGoingDown = false;
    private Vector3 targetPosition;
    private Rigidbody rb;

    [SerializeField] private Collider playerCollider;
    [SerializeField] public bigpush target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Echelle"))
        {
            tailleEchelle = other.gameObject.transform.localScale.y; //other.gameObject.GetComponent<Renderer>().bounds.size.y * 
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
        if (other.CompareTag("Echelle"))
        {
            canClimb = false;
            canGoDown = false;
        }
    }

    public void HandleClimbEchelle(InputAction.CallbackContext context)
    {
        if (context.performed && canClimb)
        {
            targetPosition = transform.position + transform.up * (tailleEchelle + offset);
            isClimbing = true;
            playerCollider.isTrigger = true;
        }
        else if (context.canceled && playerCollider != null)
        {
            isClimbing = false;
            playerCollider.isTrigger = false;
        }
    }

    public void HandleGoDownEchelle(InputAction.CallbackContext context)
    {
        if (context.performed && canGoDown)
        {
            targetPosition = transform.position + transform.up * (tailleEchelle - offset) * -1;
            isGoingDown = true;
            playerCollider.isTrigger = true;
        }
        else
        {
            isGoingDown = false;
            playerCollider.isTrigger = false;
        }
    }

    void Update()
    {
        if (isClimbing || isGoingDown)
        {
            rb.useGravity = false;
            float step = climbSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isClimbing = false;
                isGoingDown = false;
                playerCollider.isTrigger = false;
                rb.useGravity = true;
            }
        }
    }
}
