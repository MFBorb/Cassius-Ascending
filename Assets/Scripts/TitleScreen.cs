using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void StartGameButton()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
}
