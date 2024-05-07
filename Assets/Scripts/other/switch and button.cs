using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAndButton : MonoBehaviour
{
    [SerializeField] private smallactivate SmallPlayer;
    [SerializeField] private GameObject target;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player small"))
        {
            if (SmallPlayer.isActivating == true)
            {
                target.SetActive(true);
            }
            else
            {
                target.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player small"))
        {
            target.SetActive(false);
        }
    }
}
