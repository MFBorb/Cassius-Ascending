using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public int buttonID;
    public GameObject[] itemPrefabs;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;
    public ItemRandomizer randomizer;
    // Start is called before the first frame update
    void Start()
    {
        randomizer = ShopManager.GetComponent<ItemRandomizer>();
        int[] list = randomizer.getItemIDList();
        ItemID = list[buttonID];
    }
    void Update()
    {
        
        PriceText.text = "Price: $" + ShopManager.GetComponent<Store>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<Store>().shopItems[3, ItemID].ToString();
    }

}
