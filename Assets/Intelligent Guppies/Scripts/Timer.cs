using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float defaultTime = 180f;
    public Text timerDisplay;
    public Color32 txtColor, txtColorWhite;
    private float minute, second, millisecond;
    private MovingController _movingController;

    void Start()
    {
        _movingController = GameObject.Find("Player").GetComponent<MovingController>();
        timerDisplay = GameObject.Find("Timer").GetComponent<Text>();
        txtColor = new Color32(255, 255, 255, 0);
        txtColorWhite = new Color32(255, 255, 255, 255);
        timerDisplay.color = txtColor;
        //timerDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!_movingController.isCarMoved) return;

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

        timerDisplay.color = txtColorWhite;
        timerDisplay.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, millisecond);
    }
}
