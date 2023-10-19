using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeUi : MonoBehaviour
{
    public Slider timeSlider;

    private float timePlay = 126f;
    public float currentTime;

    void Start()
    {
        currentTime = timePlay;
        Update();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            Invoke("LossReLoad", 2f);
        }
        UpDateTime();
    }

    public void UpDateTime()
    {
        float timeValue = currentTime/timePlay;
        timeSlider.value = timeValue;
    }

    public void LossReLoad()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
