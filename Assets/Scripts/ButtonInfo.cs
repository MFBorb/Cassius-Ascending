using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
<<<<<<< Updated upstream
=======
    public int buttonID;
    public GameObject[] itemPrefabs;
>>>>>>> Stashed changes
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;
    public ItemRandomizer randomizer;
    // Start is called before the first frame update
<<<<<<< Updated upstream
=======
    void Start()
    {
        randomizer = ShopManager.GetComponent<ItemRandomizer>();
        int[] list = randomizer.getItemIDList();
        ItemID = list[buttonID];
    }
>>>>>>> Stashed changes
    void Update()
    {
        
        PriceText.text = "Price: $" + ShopManager.GetComponent<Store>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<Store>().shopItems[3, ItemID].ToString();
    }

}
