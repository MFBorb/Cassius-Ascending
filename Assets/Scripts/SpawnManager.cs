using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int maxEnemies;
    public int numEnemies = 0;
    public float spawnDelay;
    public float spawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObjects()
    {
        if (numEnemies < maxEnemies) {
            Vector3 spawnLocation = new Vector3(Random.Range(-7,7), Random.Range(-1, 0), 0);
            int index = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[index], spawnLocation, enemyPrefabs[index].transform.rotation);
            numEnemies++;
        }
    }
}
