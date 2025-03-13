using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndMenu : MonoBehaviour
{
    private CharacterMovement characterMovement;
    public TextMeshProUGUI ScoreText;
    private GameManager gameManager;

    void Start(){
        gameManager = GameManager.Instance;
        if(ScoreText != null){
            ScoreText.text = "TOTAL SCORE: " + gameManager.totalScore.ToString();
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameManager.scorePicked = 0;
        }
    }

    public void Restart(){
        SceneManager.LoadScene("Level1"); //Update scene with level 1
        gameManager.totalScore = 0;
        gameManager.Reset();
        PlayerPrefs.SetFloat("timer", 0);
    }
}
