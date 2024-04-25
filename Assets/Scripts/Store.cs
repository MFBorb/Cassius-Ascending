using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour
{
    public int [,] shopItems = new int[4,4];
    public CollectCoins playerCoins;
    public string coinScriptText;
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
        shopItems[2,3] = 20;
        shopItems[2,4] = 20;
        shopItems[2,5] = 20;
        shopItems[2,6] = 30;

        //Quantity
        shopItems[3,1] = 1;
        shopItems[3,2] = 2;
        shopItems[3,3] = 1;
        shopItems[3,4] = 1;
        shopItems[3,5] = 1;
        shopItems[3,6] = 1;
    }

    void activateItem(int itemID)
    {
            transform.GetChild(itemID).gameObject.SetActive(true);
            Time.timeScale = 0f;
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
        //ButtonRef.GetComponent<ButtonInfo>().ItemID = Random.Range(1, 6);
        
        if (coinScript.coins >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coinScript.coins -= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[3,ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            //ButtonRef.GetComponent<ButtonInfo>().ItemID = Random.Range(1, 6);
            //i++;
        }
    }
}
