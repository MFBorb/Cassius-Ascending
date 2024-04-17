using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    public GameObject[] heartArray;
    public Health playerHealth;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timerText;
    public CollectCoins playerCoins;

    public float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
        updateTimer(Time.deltaTime);
        updateCoins();
    }

    void updateHealthBar() {
        for (int i = 0; i < playerHealth.maxHealth; i++) {
            if (i < playerHealth.currentHealth) {
                heartArray[i].SetActive(true);
            }
            else {
                heartArray[i].SetActive(false);
            }
        }
    }

    void updateTimer(float delta) {
        timer += delta;

        string timerString = "";

        int seconds = (int) timer;
        int minutes = seconds / 60;

        timerString = string.Format("{0}:{1, 0:D2}", minutes, seconds % 60);
        timerText.text = timerString;
    }
    void updateCoins()
    {
        CollectCoins coinScript = playerCoins.GetComponent<CollectCoins>();
        string coinScriptText = coinScript.coins.ToString();
        coinText.text = coinScriptText;
    }
}
