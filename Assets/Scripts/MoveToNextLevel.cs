using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextLevel : MonoBehaviour
{
    private WaveManager waveManager;
    void Start() {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            waveManager.SetupNextWave();
            Destroy(gameObject);
        }
    }
}
