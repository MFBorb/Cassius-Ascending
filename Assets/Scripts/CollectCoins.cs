using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player" && other.gameObject.name == "Coin(Clone)")
        {
            Destroy(other.gameObject);
            coins += 1;
        }
    }
}
