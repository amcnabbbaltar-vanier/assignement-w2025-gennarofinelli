using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePowerUp : MonoBehaviour
{
    private float rotateSpeed = 50f;
    public TextMeshProUGUI ScoreText;
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);   
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Pickup(other);
        }
    }

    void Pickup(Collider player){
        Debug.Log("Power up has been picked up.");

        player.GetComponent<CharacterMovement>().score += 50;
        ScoreText.text = "SCORE: " + player.GetComponent<CharacterMovement>().score.ToString();

        gameObject.active = false;
    }
}
