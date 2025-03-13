using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour
{
    private GameManager gameManager;
    private bool hasDealtDamage = false;

    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && !hasDealtDamage){
            hasDealtDamage = true;
            Debug.Log("Player has fallen off the map!");
            gameManager.TakeDamage(2);
            gameManager.Reset();
            StartCoroutine(ReloadSceneAfterDelay(0.5f));
            return;
        }
    }

    IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hasDealtDamage = false;
    }
}
