using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnnemyManager : MonoBehaviour
{
    [SerializeField] private int _nbEnnemies = 9;
    [SerializeField] private List<Ennemy> _prefabEnnemies;
    [SerializeField] private GameObject spawnZone;
    [SerializeField] private float timerSpawn = 3f;
    [SerializeField] public GameObject movePointOne;
    [SerializeField] public GameObject movePointTwo;
    
    
    private List<Ennemy> _Ennemies = new List<Ennemy>();
    private int currentSpawnIndex = 0;
    
    void Start()
    {
        Spawn();
    }


    public void Spawn()
    {
        if (currentSpawnIndex < _nbEnnemies)
        {
            Vector3 position = spawnZone.transform.position;
            Ennemy instance = Instantiate<Ennemy>(_prefabEnnemies[Random.Range(0, _prefabEnnemies.Count)], position, Quaternion.identity, this.transform);
            
            instance.IsTouched += EnnemyTouched;
            _Ennemies.Add(instance);

            currentSpawnIndex++;
            Invoke("Spawn", timerSpawn);
        }
    }

    public void EnnemyTouched(Ennemy Ennemy)
    {
        if (_Ennemies.Contains(Ennemy))
        {
            Debug.Log("Ennemy touched !!!!!!!!!!");
            _Ennemies.Remove(Ennemy);
        }
    }
}
