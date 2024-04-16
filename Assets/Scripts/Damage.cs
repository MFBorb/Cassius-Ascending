using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Variable Declarations

    // Public variables
    public int damageValue = 1;

    // Private variables
        // None yet.

    // Damage function. Currently only damages whenever we enter an object
    void OnTriggerEnter2D(Collider2D col) {
        Health healthScript = col.transform.gameObject.GetComponent<Health>();

        if (healthScript.gameObject.name == "Player") {
            healthScript.PlayerDamage(damageValue);
        }
        else {
            healthScript.Damage(damageValue);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        Health healthScript = col.transform.gameObject.GetComponent<Health>();

        if (healthScript.gameObject.name == "Player") {
            healthScript.PlayerDamage(damageValue);
        }
        else {
            healthScript.Damage(damageValue);
        }
    }
}
