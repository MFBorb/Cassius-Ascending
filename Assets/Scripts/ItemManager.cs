using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject sparkPrefab;

    public void ActivateOnHitEffects(GameObject obj) {
        foreach (Item item in items) {
            item.OnHit(obj);
        }
    }

    public void ActivateOnActivationEffects() {
        foreach (Item item in items) {
            item.OnActivation();
        }
    }
}
