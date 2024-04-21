using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject platformPrefab;
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "wall") {
            Destroy(col.gameObject);
        }
    }

    public void Death() {
        Instantiate(platformPrefab, new Vector3(0, 0, 0), platformPrefab.transform.rotation);
    }
}
