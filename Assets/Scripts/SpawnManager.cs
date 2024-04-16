using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
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
        Vector3 spawnLocation = new Vector3(10, Random.Range(3, 20), 0);
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], spawnLocation, enemyPrefabs[index].transform.rotation);
    }
}
