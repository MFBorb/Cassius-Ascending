using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject target;
    [Range(0, 10)]
    private float speed = 2f;
    public int damageValue = 1;
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            Health healthScript = other.transform.gameObject.GetComponent<Health>();

            healthScript.PlayerDamage(damageValue);
            Destroy(gameObject);
        }
    }
}
