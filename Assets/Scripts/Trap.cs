using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trap : MonoBehaviour
{
    private GameManager health;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            health = GameManager.Instance;
            health.TakeDamage(1);
            other.GetComponent<CharacterMovement>().health -= 1;
        }
    }
}
