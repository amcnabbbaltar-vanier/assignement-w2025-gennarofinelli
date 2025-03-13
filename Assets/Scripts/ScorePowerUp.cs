using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePowerUp : MonoBehaviour
{
    private float rotateSpeed = 50f;
    private TextMeshProUGUI ScoreText;
    private Vector3 startPos;
    private GameManager gameManager;

    void Start(){
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        startPos = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        transform.Rotate(0,rotateSpeed * Time.deltaTime, 0);
        float newY = Mathf.Sin(Time.time * 5) * 0.25f;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);
        }
    }

    void Pickup(Collider player){
        gameManager.IncrementScore();
        ScoreText.text = "SCORE: " + gameManager.totalScore.ToString();

        gameObject.SetActive(false);
    }
}
