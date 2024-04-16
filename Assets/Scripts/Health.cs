using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Variable declarations

    // Public declarations
    public int maxHealth;
    public int currentHealth;
    public float invulnSeconds = 0.5f;

    // Private declarations
    private bool canTakeDamage = true;

    // Damage the gameObject by the damage amount. Handle death if we are below 0 health.
    public void Damage(int damageValue) {
        Debug.Log(name + " took " + damageValue + " damage.");
        currentHealth -= damageValue;
        if(isDead()) {
            Death();
        }
    }

    public void PlayerDamage(int damageValue) {
        if (canTakeDamage) {
            Debug.Log(name + " took " + damageValue + " damage.");
            currentHealth -= damageValue;
            if(isDead()) {
                Death();
            }
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability() {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnSeconds);
        canTakeDamage = true;
    }

    // Heal the gameObject by the heal amount. We don't want our current health to go above the max health though.
    public void Heal(int healValue) {
        Debug.Log(name + " healed " + healValue + " health.");    // Will show the wrong value if currentHealth + healValue > maxHealth
        currentHealth = Mathf.Max(currentHealth + healValue, maxHealth);
    }

    // Increase the max health by the increase value. Could set a limit on max health.
    // Also give the user the health they just gained.
    public void increaseMaxHealth(int increaseValue) {
        Debug.Log(name + " gained " + increaseValue + " health.");
        maxHealth += increaseValue;
        currentHealth += increaseValue;
    }

    // Simply returns true if our current health is at or below zero. False otherwise.
    private bool isDead() {
        return currentHealth <= 0 ? true : false;
    }

    // Simple death script. Could abstract this to enemy and player death.
    private void Death() {
        Debug.Log(name + " died.");
        Destroy(gameObject);
    }
}
