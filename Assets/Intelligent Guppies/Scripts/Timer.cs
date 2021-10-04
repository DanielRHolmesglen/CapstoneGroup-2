using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float defaultTime = 180f;
    public Text timerDisplay;
    private float minute, second, millisecond;

    void Start()
    {
        timerDisplay = GameObject.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        if (defaultTime > 0)
        {
            defaultTime -= Time.deltaTime;
        }
        else
        {
            defaultTime = 0;
        }

        DisplayTime(defaultTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        minute = Mathf.FloorToInt(timeToDisplay / 60);
        second = Mathf.FloorToInt(timeToDisplay % 60);
        millisecond = timeToDisplay % 1 * 1000;

        timerDisplay.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, millisecond);
    }
}
