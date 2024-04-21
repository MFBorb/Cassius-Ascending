using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject target; //the enemy's target
    public GameObject[] dropOnDeathPrefabs;
    public float moveSpeed = .005f; //move speed
	private Vector2 enemyMove;
    public int damageValue = 1;
    [SerializeField] private float health;
    private Animator anim;

    private SpawnManager enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        enemySpawner = GameObject.Find("Enemies").GetComponent<SpawnManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);
        }

        if (transform.position.x < target.transform.position.x)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            enemySpawner.numEnemies--;
            Instantiate(dropOnDeathPrefabs[Random.Range(0, dropOnDeathPrefabs.Length)], transform.position, transform.rotation);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health healthScript = other.transform.gameObject.GetComponent<Health>();

            healthScript.PlayerDamage(damageValue);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Health healthScript = other.transform.gameObject.GetComponent<Health>();

            healthScript.PlayerDamage(damageValue);
        }
    }
}
