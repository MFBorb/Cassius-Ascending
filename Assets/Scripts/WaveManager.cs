using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject player;
    public GameObject tileManager;
    public GameObject enemyManager;
    public HudManager timer;
    public int wave = 0;


    void Start() {
        SetupNextWave();
    }

    public void SetupNextWave() {
        wave++;

        if (wave == 10) {
            timer.ActivateWin();
            return;
        }
        
        DestroyPickups();
        DestroyProjectiles();
        DestroyEnemies();
        DestroyTiles();
        ResetPlayer();
        ResetTimerAndWave();

        StartEnemies();
        StartTiles();
    }

    private void DestroyPickups() {
        GameObject[] pickupArray = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject pickup in pickupArray) {
            Destroy(pickup);
        }
    }

    private void DestroyProjectiles() {
        GameObject[] projectileArray = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject projectile in projectileArray) {
            Destroy(projectile);
        }
    }

    private void DestroyEnemies() {
        foreach (Transform child in enemyManager.transform) {
            Destroy(child.gameObject);
        }
    }

    private void DestroyTiles() {
        foreach(Transform child in tileManager.transform) {
            Destroy(child.gameObject);
        }
    }

    private void ResetPlayer() {
        player.transform.position = new Vector3(0.0f, 0.125f, 0.0f);
    }

    private void ResetTimerAndWave() {
        timer.wave = wave;
        timer.timer = 0.0f;
    }

    private void StartEnemies() {
        SpawnManager spawnManager = enemyManager.GetComponent<SpawnManager>();
        spawnManager.maxEnemies = 10 + 2 * wave;

        spawnManager.StartSpawning(1.55f - ((float) wave) / 9.0f);
    }

    private void StartTiles() {
        GenerateTiles tileGen = tileManager.GetComponent<GenerateTiles>();

        tileGen.StartTileGeneration();
    }
}
