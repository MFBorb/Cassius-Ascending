using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChlorineAOE : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Enemy1")
        {
            col.GetComponent<EnemyMovement>().TakeDamage(damage * Time.deltaTime);
        }
        else if (col.tag == "Enemy2")
        {
            col.GetComponent<RangedEnemy>().TakeDamage2(damage * Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Enemy1")
        {
            col.GetComponent<EnemyMovement>().TakeDamage(damage * Time.deltaTime);
        }
        else if (col.tag == "Enemy2")
        {
            col.GetComponent<RangedEnemy>().TakeDamage2(damage * Time.deltaTime);
        }
    }
}
