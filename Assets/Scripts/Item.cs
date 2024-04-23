using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void Start() {
        OnBuy();
    }

    public virtual void OnBuy() {
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
        StartCoroutine("AfflictBleed", obj);
    }

    IEnumerator AfflictBleed(GameObject obj) {
        if (obj.tag == "Enemy1") {
            EnemyMovement healthScript = obj.GetComponent<EnemyMovement>();

            for (int i = 0; i < 3; i++) {
                healthScript.TakeDamage(10.0f);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else {
            RangedEnemy healthScript = obj.GetComponent<RangedEnemy>();

            for (int i = 0; i < 3; i++) {
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
            StartCoroutine("ActivateEffect");
        }
    }

    IEnumerator ActivateEffect() {
        canActivate = false;

        playerSpeed.speed += 1.5f;
        playerAttack.meleeSpeed -= 0.1f;

        yield return new WaitForSeconds(3.0f);

        playerSpeed.speed -= 1.5f;
        playerAttack.meleeSpeed += 0.1f;

        canActivate = true;
    }
}

public class Chlorine : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        GameObject chlorineAOE = player.transform.Find("chlorineAOE").gameObject;
        Instantiate(chlorineAOE, chlorineAOE.transform.position, chlorineAOE.transform.rotation, player.transform).SetActive(true);
        
    }
}

public class Carbon : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        player.GetComponent<Attack>().enemyDamage += 25.0f;

        player.transform.Find("WeaponParent").localScale += new Vector3(0.1f, 0.1f, 0.0f);
        
    }
}

public class Iron : Item {
    private GameObject player;

    public override void OnBuy() {

        player = GameObject.Find("Player");
        
        player.GetComponent<Attack>().enemyDamage += 25.0f;
        
    }
}

public class Copper : Item {

}

public class Helium : Item {

    public override void OnBuy()
    {
        GameObject player = GameObject.Find("Player");
        PlayerMovement playerSpeed = player.GetComponent<PlayerMovement>();

        playerSpeed.speed += 1.0f;
    }
    
}

public class Steel : Item {
    public override void OnBuy()
    {
        GameObject player = GameObject.Find("Player");
        Attack playerAttack = player.GetComponent<Attack>();
        playerAttack.meleeSpeed -= 0.1f;
    }
}