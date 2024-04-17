using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed = 1;
    [SerializeField] private float enemyDamage;
    float timeUntilMelee = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
                
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Enemy1")
        {
            other.GetComponent<EnemyMovement>().TakeDamage(enemyDamage);
        }
        if (other.tag == "Enemy2")
        {
            other.GetComponent<RangedEnemy>().TakeDamage2(enemyDamage);
        }
    }
}
