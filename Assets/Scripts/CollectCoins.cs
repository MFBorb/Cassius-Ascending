using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public float coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player" && other.tag == "Coin")
        {
            Destroy(other.gameObject);
            coins += 1f;
        }
    }
}
