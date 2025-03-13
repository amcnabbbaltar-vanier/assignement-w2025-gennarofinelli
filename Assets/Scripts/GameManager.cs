using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int score = 0;
    public int maxHealth = 3;
    public int currentHealth;
    public Slider healthBar;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            currentHealth = maxHealth;
            healthBar.maxValue = maxHealth;
            healthBar.value = GameManager.Instance.currentHealth;
            DontDestroyOnLoad(gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Modify this function
    public void IncrementScore()
    {
        score+=50;
        Debug.Log("Score: " + score);
    }
    // Change the name of this Function 
    public void LoadNextScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = GameManager.Instance.currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
