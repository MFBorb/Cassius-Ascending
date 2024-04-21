using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChanges : MonoBehaviour
{
    public GameObject[] heldItems;
    public GameObject player;
    public Attack playerDamage;
    public PlayerMovement moveSpeed;
    public int iron;
    public int chlorine;
    public int hydrogen;
    public int oxygen;
    public int copper;
    public int carbon;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDamage = player.GetComponent<Attack>();
        moveSpeed = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkItem()
    {
        
        if (heldItems[i].gameObject.tag == "iron")
        {
            iron++;
            playerDamage.enemyDamage += 25;
        }
        else if (heldItems[i].gameObject.tag == "chlorine")
        {
            chlorine++;
        }
        else if (heldItems[i].gameObject.tag == "hydrogen")
        {
            moveSpeed.speed += 0.5f;
            hydrogen++;
        }
        else if (heldItems[i].gameObject.tag == "oxygen")
        {
            oxygen++;
        }
        else if (heldItems[i].gameObject.tag == "copper")
        {
            copper++;
        }
        else if (heldItems[i].gameObject.tag == "carbon")
        {
            carbon++;
        }
        i++;
        
    }
}
