using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public GameObject pause;
    public GameObject resume;
    public GameObject restart;
    public GameObject quit;
    private bool isPaused = true;

    public void NextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene1");
    }

    public void NextScene2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene2");
    }

    public void NextScene3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene3");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (isPaused == true)
        {
            pause.SetActive(false);
            Time.timeScale = 0;
            resume.SetActive(true);
            restart.SetActive(true);
            quit.SetActive(true);
        }
        else
        {
            pause.SetActive(true);
            Time.timeScale = 1;
            pause.SetActive(true);
            resume.SetActive(false);
            restart.SetActive(false);
            quit.SetActive(false);
        }

        isPaused = !isPaused;
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(ObjectManager.instance.lastScene);
    }
}
