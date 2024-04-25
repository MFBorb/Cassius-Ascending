using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public ItemManager itemManager;
    public CollectCoins coins;
    public int cost = 5;
    public TextMeshProUGUI[] buttonText = new TextMeshProUGUI[3];
    private string[] validItems;

    private string[] itemsInShop;

    public void GenerateRandomItems() {
        validItems = ItemManager.itemNames;
        itemsInShop = new string[3];

        // Generate 3 items and make sure there are no repeats.
        for (int i = 0; i < 3; i++) {
            string potentialItem;

            do {
                int randomItem = Random.Range(0, validItems.Length);
                potentialItem = validItems[randomItem];
                validItems[randomItem] = null;
            } while (potentialItem == null);

            itemsInShop[i] = potentialItem;
        }

        UpdateButtonText();
    }

    private void BuyItem(int index) {
        if (cost <= coins.coins) {
            itemManager.Buy(itemsInShop[index]);
            coins.coins -= cost;

            cost += 5;

            UpdateButtonText();
        }
    }

    private void UpdateButtonText() {
        for (int i = 0; i < 3; i++) {
            buttonText[i].text = itemsInShop[i] + " - " + cost + " coins";
        }
    }

    public void Button0() {
        BuyItem(0);
    }

    public void Button1() {
        BuyItem(1);
    }

    public void Button2() {
        BuyItem(2);
    }
}
