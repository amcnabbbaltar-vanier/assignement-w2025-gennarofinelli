using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeMenu : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = PlayerPrefs.GetFloat("timer", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        PlayerPrefs.SetFloat("timer", timer);
        TimerText.text = "TIME: " + Mathf.FloorToInt(timer).ToString();
    }
}
