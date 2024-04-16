using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public GameObject projectilePrefab;
    public GameObject coinPrefab;
    public float moveSpeed = .005f; //move speed
	private Vector2 enemyMove;
    [SerializeField] private float health;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public float rotateSpeed;
    public float fireRate;
    private float timeToFire;
    public Transform firingPoint;
    // Start is called before the first frame update
    void Start()
    {
        timeToFire = fireRate;
        target = GameObject.Find("Player");
        //projectilePrefab = GameObject.Find("projectilePrefab");
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
        if (timeToFire <= 0f)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    public void TakeDamage2(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Instantiate(coinPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
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
