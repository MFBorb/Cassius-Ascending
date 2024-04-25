using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemRandomizer : MonoBehaviour
{
    public GameObject[] itemSprites;
    //public GameObject item;
    private int[] ItemID = new int[3];
    // Start is called before the first frame update
    void Start() {
        //initialize item list to 1's by default
        //ItemID = [1,1,1];
        
        // randomize items -> make sure two items are the same
        int Item1 = Random.Range(1, itemSprites.Length);
        int Item2 = Random.Range(1, itemSprites.Length);
        while (Item2 == Item1) {
            Item2 = Random.Range(1, itemSprites.Length);
        }
        int Item3 = Random.Range(1, itemSprites.Length);
        while (Item3 == Item1 || Item3 == Item2) {
            Item2 = Random.Range(1, itemSprites.Length);
        }

        ItemID[0] = Item1;
        ItemID[1] = Item2;
        ItemID[2] = Item3;
    }


    public int[] getItemIDList() {
        return ItemID;
    }
    // Update is called once per frame
}
