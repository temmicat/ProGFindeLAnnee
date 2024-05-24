using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dying : MonoBehaviour
{ 
    public bool GameOn = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lethal"))
        {
            GameOn = false;
            Debug.Log("Game over.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
