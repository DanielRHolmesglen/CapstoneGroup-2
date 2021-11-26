using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float defaultTime = 180f;
    //public Text txtTimer;
    public TextMesh txtTimer;
    public Color32 txtColor, txtColorWhite;
    private float minute, second, millisecond;
    private CarController _carController;
    private Transform cameraTarget;
    private Vector3 cameraOffset;

    void Start()
    {
        _carController = GameObject.Find("Player").GetComponent<CarController>();
        txtTimer = GameObject.Find("Timer").GetComponent<TextMesh>();
        txtColor = new Color32(255, 255, 255, 0);
        txtColorWhite = new Color32(255, 255, 255, 255);
        txtTimer.color = txtColor;
        cameraTarget = GameObject.Find("Player").transform;
        cameraOffset = transform.position - cameraTarget.position;
        //timerDisplay.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!_carController.isCarMoved) return;

        Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y,
            cameraOffset.z + cameraTarget.position.z);
        transform.position = cameraPosition;

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

        txtTimer.color = txtColorWhite;
        //txtTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minute, second, millisecond);
        txtTimer.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
