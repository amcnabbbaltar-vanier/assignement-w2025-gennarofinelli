using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start(){
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetFloat("timer", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
