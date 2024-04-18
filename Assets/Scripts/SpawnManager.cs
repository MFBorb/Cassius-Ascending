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

    public float enemy1Weight;
    public float enemy2Weight;


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
            Vector3 spawnLocation = new Vector3(Random.Range(-8,9), Random.Range(-4, 5), 0);
            int index;
            float randomWeight = Random.Range(0, 1);

            if (randomWeight <= enemy1Weight) {
                index = 0;
            }
            else {
                index = 1;
            }

            Instantiate(enemyPrefabs[index], spawnLocation, enemyPrefabs[index].transform.rotation, this.gameObject.transform);
            numEnemies++;
        }
    }
}
