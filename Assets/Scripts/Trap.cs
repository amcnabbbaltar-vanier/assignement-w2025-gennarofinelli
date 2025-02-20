using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trap : MonoBehaviour
{
    public TextMeshProUGUI HealthText;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            other.GetComponent<CharacterMovement>().health -= 1;
            HealthText.text = "HEALTH: " + other.GetComponent<CharacterMovement>().health.ToString();
        }
    }
}
