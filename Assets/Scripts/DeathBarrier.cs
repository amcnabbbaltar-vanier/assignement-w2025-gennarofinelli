using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private GameManager characterHealth;
    private bool hasDealtDamage = false;

    void Start()
    {
        characterHealth = GameManager.Instance;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && !hasDealtDamage){
            hasDealtDamage = true;
            Debug.Log("Player has fallen off the map!");
            characterHealth.TakeDamage(2);
            StartCoroutine(ReloadSceneAfterDelay(0.5f));
            return;
        }
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
        hasDealtDamage = false;
    }
}
