using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    
    public List<Item> items = new List<Item>();
    public static string[] itemNames = {"HCl", "Glucose", "Chlorine", "Carbon",
                                        "Iron", "Copper", "Helium", "Steel"};
    public GameObject sparkPrefab;

    void Start() {
        //foreach (string name in itemNames) {
            //Buy(name);
        //}
    }

    public void Buy(string item) {
        switch (item) {
            case "HCl":
                items.Add(gameObject.AddComponent(typeof(HCl)) as HCl);
                break;
            case "Glucose":
                items.Add(gameObject.AddComponent(typeof(Glucose)) as Glucose);
                break;
            case "Chlorine":
                items.Add(gameObject.AddComponent(typeof(Chlorine)) as Chlorine);
                break;
            case "Carbon":
                items.Add(gameObject.AddComponent(typeof(Carbon)) as Carbon);
                break;
            case "Iron":
                items.Add(gameObject.AddComponent(typeof(Iron)) as Iron);
                break;
            case "Copper":
                items.Add(gameObject.AddComponent(typeof(Copper)) as Copper);
                break;
            case "Helium":
                items.Add(gameObject.AddComponent(typeof(Helium)) as Helium);
                break;
            case "Steel":
                items.Add(gameObject.AddComponent(typeof(Steel)) as Steel);
                break;
        }
    }

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
