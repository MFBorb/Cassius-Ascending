using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            Health healthScript = col.transform.gameObject.GetComponent<Health>();

            healthScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
