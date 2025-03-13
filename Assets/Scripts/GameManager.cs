using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int totalScore = 0;
    public int scorePicked = 0;
    private TextMeshProUGUI ScoreText;
    public int maxHealth = 3;
    public int currentHealth;
    public Slider healthBar;
    public float timer = 0;
    private TextMeshProUGUI TimerText;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            TimerText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
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

    void Update()
    {
        timer += Time.deltaTime;
        TimerText.text = "TIME: " + Mathf.FloorToInt(timer).ToString();
    }

    // Modify this function
    public void IncrementScore()
    {
        scorePicked+=1;
        totalScore += 50;
    }
    // Change the name of this Function 
    public void LoadNextScene()
    {
       if(SceneManager.GetActiveScene().name != "EndScreen"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
       } else if (SceneManager.GetActiveScene().name == "EndScreen"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );

       }
       
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

    public void Reset(){
        if(totalScore!=0){
            totalScore -= 50 * scorePicked;
        }
        scorePicked = 0;
        ScoreText.text = "SCORE: " + totalScore;
        TimerText.text = "TIME: " + Mathf.FloorToInt(timer).ToString();
    }
}
