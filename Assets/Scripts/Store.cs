using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour
{
    public int [,] shopItems = new int[4,7];
    public GameObject[] itemPrefabs;
    public CollectCoins playerCoins;
    public string coinScriptText;
    public ItemChanges boughtItem;

    // Start is called before the first frame update
    void Start()
    {
        
        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;
        shopItems[1,5] = 5;
        shopItems[1,6] = 6;

        //Price
        shopItems[2,1] = 10;
        shopItems[2,2] = 10;
        shopItems[2,3] = 10;
        shopItems[2,4] = 10;
        shopItems[2,5] = 10;
        shopItems[2,6] = 10;
        

        //Quantity
        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
        shopItems[3,5] = 0;
        shopItems[3,6] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CollectCoins coinScript = playerCoins.GetComponent<CollectCoins>();
        coinScriptText = coinScript.coins.ToString();
    }
    
    public void Buy()
    {
        CollectCoins coinScript = playerCoins.GetComponent<CollectCoins>();
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        ButtonRef.GetComponent<ButtonInfo>().ItemID = Random.Range(1, 6);
        
        if (coinScript.coins >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            boughtItem.GetComponent<ItemChanges>().checkItem();
            coinScript.coins -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
