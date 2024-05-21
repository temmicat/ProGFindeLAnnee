using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    public event Action<Ennemy> IsTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player Big"))
        {
            IsTouched?.Invoke(this);
            Destroy(gameObject);
        }    
    }
}
