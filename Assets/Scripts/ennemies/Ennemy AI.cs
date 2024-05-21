using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyAI : MonoBehaviour
{
    private float speed = 5f;
    private EnnemyManager ennemyManager;
    private Vector3 currentMovePoint;
    private GameObject movePointOne;
    private GameObject movePointTwo;
    
    void Start()
    {
        ennemyManager = GetComponentInParent<EnnemyManager>();
        movePointOne = ennemyManager.movePointOne;
        movePointTwo = ennemyManager.movePointTwo;
        currentMovePoint = movePointTwo.transform.position;
    }
    
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentMovePoint, step);
        Debug.Log("moving ennemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == movePointOne)
        {
            currentMovePoint = movePointTwo.transform.position ;
        }
        if (other.gameObject == movePointTwo)
        {
            currentMovePoint = movePointOne.transform.position ;
        }
    }
}
