using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class HudManager : MonoBehaviour
{
    public GameObject[] heartArray;
    public Health playerHealth;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI timerText;
    public CollectCoins playerCoins;
    public GameOverScreen gameOverScreen;
    public WinScreen winScreen;
    public int wave = 0;

    public float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
        updateTimer(Time.deltaTime);
        updateCoins();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activateShop();
        }
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

        if (playerHealth.currentHealth <= 0)
        {
            gameOverScreen.GameOver();
        }
    }

    void updateTimer(float delta) {
        timer += delta;

        string timerString = "";

        int seconds = (int) timer;
        int minutes = seconds / 60;

        string waveString = "Wave " + wave + " - ";

        timerString = string.Format("{0}:{1, 0:D2}", minutes, seconds % 60);
        timerText.text = waveString + timerString;
    }
    void updateCoins()
    {
        CollectCoins coinScript = playerCoins.GetComponent<CollectCoins>();
        string coinScriptText = coinScript.coins.ToString();
        coinText.text = coinScriptText;
    }
    void activateShop()
    {
        if (transform.GetChild(5).gameObject.activeSelf == false)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            transform.GetChild(5).gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        
    }

    public void ActivateWin() {
        playerHealth.gameObject.SetActive(false);
        winScreen.YouWin();
    }

}
