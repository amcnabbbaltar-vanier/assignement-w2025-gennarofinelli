using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    private GameManager gameManager;
    public GameObject PauseMenuCanvas;   
    public GameObject ScoreCanvas;

    void Start()
    {
        Time.timeScale = 1f;
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        ScoreCanvas.SetActive(false);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        ScoreCanvas.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Quit(){
        PauseMenuCanvas.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart(){
        PauseMenuCanvas.SetActive(false);
        Play();
        gameManager.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
