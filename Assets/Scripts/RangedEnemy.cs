using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public GameObject projectilePrefab;
    public GameObject[] dropOnDeathPrefabs;
    public float moveSpeed = .005f; //move speed
	private Vector2 enemyMove;
    [SerializeField] private float health;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public float rotateSpeed;
    public float fireRate;
    private float timeToFire;
    private float timeToFireAnimation;
    public Transform firingPoint;
    private Animator anim;

     private SpawnManager enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        timeToFire = fireRate;
        target = GameObject.Find("Player");
        enemySpawner = GameObject.Find("Enemies").GetComponent<SpawnManager>();
        //projectilePrefab = GameObject.Find("projectilePrefab");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
        if (Vector2.Distance(target.transform.position, transform.position) >= distanceToStop)
        {
        
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);
        }
        if (Vector2.Distance(target.transform.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        // trigger about to fire animation
        if (timeToFire > 0f && timeToFire <= 1f)
        {
            anim.SetTrigger("Fire");
            timeToFireAnimation = fireRate;
        }
        else
        {
            timeToFireAnimation -= Time.deltaTime;
        }

        // Fire Attack
        if (timeToFire <= 0f)
        {
            GameObject projectileClone = Instantiate(projectilePrefab, transform.position, transform.rotation);

            timeToFire = fireRate;
        }
        else
        {
            timeToFireAnimation -= Time.deltaTime;
            timeToFire -= Time.deltaTime;
            
        }
    }
    public void TakeDamage2(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            GameObject pickupPrefab = dropOnDeathPrefabs[Random.Range(0, dropOnDeathPrefabs.Length)];
            Instantiate(pickupPrefab, transform.position, pickupPrefab.transform.rotation);
            
            Destroy(gameObject);
            enemySpawner.numEnemies--;
        }
    }
    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0,0,angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

}
