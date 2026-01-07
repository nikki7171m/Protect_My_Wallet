using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] GameObject objOnOff;

    [SerializeField] private Text timeText;

    [SerializeField] private float starTime;
    private float time;

    private bool timeActive = true;


    void Start()
    {
        timeActive = true;
        time = starTime;
        timeText.text = time.ToString("F2");
    }

    void Update()
    {
        ReduceTime();
    }

    public void ReduceTime()
    {
        if (time > 0)
        {
            objOnOff.SetActive(false);

            time -= Time.deltaTime;
            timeText.text = time.ToString("F2");
        }
        else if (time <= 0 && timeActive == true)
        {
            objOnOff.SetActive(true);

            Time.timeScale = 0f;

            timeActive = false;
            time = 0;
            timeText.text = time.ToString("F2");
        }
    }
}
