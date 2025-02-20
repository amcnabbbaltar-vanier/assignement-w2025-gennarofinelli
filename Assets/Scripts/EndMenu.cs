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

    void Start(){
        int score = PlayerPrefs.GetInt("score", 0);

        ScoreText.text = "TOTAL SCORE: " + score.ToString();
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene"); //Update scene with level 1
    }
}
