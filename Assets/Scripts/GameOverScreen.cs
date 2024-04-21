using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void GameOver()
    {
        gameObject.SetActive(true);
    }

    // TODO
    public void TryAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}