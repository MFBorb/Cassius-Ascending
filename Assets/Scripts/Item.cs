using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void Start() {
        OnBuy();
    }

    public virtual void OnBuy() {
        Debug.Log(this.GetType().Name + " was bought");
        return;
    }

    public virtual void OnHit(GameObject obj) {
        return;
    }

    public virtual void OnActivation() {
        return;
    }
}

public class HCl : Item {
    public override void OnHit(GameObject obj) {
        Debug.Log("Starting bleed");
        StartCoroutine("AfflictBleed", obj);
    }

    IEnumerator AfflictBleed(GameObject obj) {
        if (obj.tag == "Enemy1") {
            EnemyMovement healthScript = obj.GetComponent<EnemyMovement>();

            for (int i = 0; i < 3; i++) {
                if (healthScript == null) {
                    yield break;
                }
                healthScript.TakeDamage(10.0f);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else {
            RangedEnemy healthScript = obj.GetComponent<RangedEnemy>();

            for (int i = 0; i < 3; i++) {
                if (healthScript == null) {
                    yield break;
                }
                healthScript.TakeDamage2(10.0f);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}

public class Glucose : Item {
    private PlayerMovement playerSpeed;
    private Attack playerAttack;

    private bool canActivate = true;

    public override void OnBuy()
    {
        GameObject player = GameObject.Find("Player");
        playerSpeed = player.GetComponent<PlayerMovement>();
        playerAttack = player.GetComponent<Attack>();
    }

    public override void OnActivation()
    {
        if(canActivate) {
            Debug.Log("Player activated glucose");
            StartCoroutine("ActivateEffect");
        }
    }

    IEnumerator ActivateEffect() {
        canActivate = false;

        playerSpeed.speed += 2.5f;
        playerAttack.meleeSpeed -= 0.1f;

        yield return new WaitForSeconds(3.0f);

        playerSpeed.speed -= 2.5f;
        playerAttack.meleeSpeed += 0.1f;

        yield return new WaitForSeconds(5.0f);

        canActivate = true;
    }
}

public class Chlorine : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        GameObject chlorineAOE = player.transform.Find("chlorineAOE").gameObject;
        Instantiate(chlorineAOE, chlorineAOE.transform.position, chlorineAOE.transform.rotation, player.transform).SetActive(true);

        Debug.Log("Player bought chlorine aoe");
        
    }
}

public class Carbon : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        player.GetComponent<Attack>().enemyDamage += 25.0f;

        player.transform.Find("WeaponParent").localScale += new Vector3(0.1f, 0.1f, 0.0f);

        Debug.Log("Player bought Carbon");
        
    }
}

public class Iron : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        player.GetComponent<Attack>().enemyDamage += 25.0f;

        Debug.Log("Iron was bought. Increased user damage to " + player.GetComponent<Attack>().enemyDamage);
        
    }
}

public class Copper : Item {
    public override void OnHit(GameObject obj) {
        Collider2D[] results;
        GameObject spark = gameObject.GetComponent<ItemManager>().sparkPrefab;
        AudioSource shock = gameObject.GetComponent<AudioSource>();

        results = Physics2D.OverlapCircleAll(obj.transform.position, 1.0f);

        foreach (Collider2D col in results) {
            if (col.gameObject.tag == "Enemy1") {
                Debug.Log("Enemy hit");
                col.gameObject.GetComponent<EnemyMovement>().TakeDamage(10.0f);

                Instantiate(spark, col.gameObject.transform.position, spark.transform.rotation);
            }
            else if (col.gameObject.tag == "Enemy2") {
                Debug.Log("Enemy hit");
                col.gameObject.GetComponent<RangedEnemy>().TakeDamage2(10.0f);

                Instantiate(spark, col.gameObject.transform.position, spark.transform.rotation);
            }
        }

        Instantiate(spark, obj.transform.position, spark.transform.rotation);
    }
}

public class Helium : Item {

    public override void OnBuy()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerSpeed = player.GetComponent<PlayerMovement>();

        playerSpeed.speed += 1.0f;

        Debug.Log("Helium was bought.");
    }
    
}

public class Steel : Item {
    public override void OnBuy()
    {
        GameObject player = GameObject.Find("Player");
        Attack playerAttack = player.GetComponent<Attack>();
        playerAttack.meleeSpeed -= 0.1f;

        Debug.Log("Steel was bought.");
    }
}