using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public GameObject coinPrefab;
    public float moveSpeed = .005f; //move speed
	private Vector2 enemyMove;
    public int damageValue = 1;
    [SerializeField] private float health;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            Instantiate(coinPrefab, transform.position, transform.rotation);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health healthScript = other.transform.gameObject.GetComponent<Health>();

            healthScript.Damage(damageValue);
        }
    }
}
