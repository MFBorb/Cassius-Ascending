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
    private Vector3 objectScale;
    // Start is called before the first frame update
    void Start()
    {
        objectScale = transform.localScale;
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
            transform.localScale = new Vector3(-objectScale.x, objectScale.y, objectScale.z);
        }
        else
        {
            transform.localScale = new Vector3(objectScale.x, objectScale.y, objectScale.z);
        }
    }
    public void TakeDamage(float damage)
    {
        // Do not remove this. Weird bug with items causing multiple death triggers.
        if (health <= 0f) { return; };
        health -= damage;
        if (health <= 0f)
        {
            if (gameObject.name == "BossEnemy(Clone)") {
                gameObject.GetComponent<BossEnemy>().Death();
            }

            GameObject pickupPrefab = dropOnDeathPrefabs[Random.Range(0, dropOnDeathPrefabs.Length)];
            Instantiate(pickupPrefab, transform.position, pickupPrefab.transform.rotation);
            
            Destroy(gameObject);
            enemySpawner.numEnemies--;
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
