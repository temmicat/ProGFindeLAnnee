using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activableteleport : MonoBehaviour
{
    [SerializeField] private Collider triggerable;
    [SerializeField] private activableteleport linkedPortal;
    public bool teleportedSmall = false;
    public bool teleportedBig = false;
    private Vector3 offset = new Vector3 (0f, -0.5f, 0f);
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player small"))
        {
            if (teleportedSmall == false)
            {
                linkedPortal.teleportedSmall = true;
                other.gameObject.transform.position = linkedPortal.transform.position ;
            }
        }
        if (other.CompareTag("player big"))
        {
            if (teleportedBig == false)
            {
                linkedPortal.teleportedBig = true;
                other.gameObject.transform.position = linkedPortal.transform.position ;   
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player small"))
        {
            teleportedSmall = false;
        }
        if (other.CompareTag("player big"))
        {
            teleportedBig = false;
        }
    }
    
}
