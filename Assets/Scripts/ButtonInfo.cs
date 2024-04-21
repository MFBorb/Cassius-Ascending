using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public GameObject[] itemPrefabs;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
        ItemID = Random.Range(1, itemPrefabs.Length-1);
        
    }
    void Update()
    {
        
        PriceText.text = "Price: $" + ShopManager.GetComponent<Store>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<Store>().shopItems[3, ItemID].ToString();
    }

}
