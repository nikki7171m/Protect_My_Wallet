using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static bool firstTime= true;
    public static bool firstAfterGameplay = true;

    public void LoadSceneGameplay()
    {
        if (firstTime == true)
        {
            firstTime = false;
            SceneManager.LoadScene("Gameplay_First");
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void LoadSceneStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadSceneInvestment()
    {
        SceneManager.LoadScene("Investment");
    }

    public void LoadSceneAfterGameplay()
    {
        SceneManager.LoadScene("AfterGameplay");
    }
}
