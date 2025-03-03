using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private CharacterHealth characterHealth;

    void Start()
    {
        characterHealth = GameObject.Find("Player").GetComponent<CharacterHealth>();
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Player has fallen off the map!");
            characterHealth.TakeDamage(1);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
