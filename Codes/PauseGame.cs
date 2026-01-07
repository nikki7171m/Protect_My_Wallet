    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private bool isPause = false;
    public void PauseGame_ButtonClick()
    {
        if (isPause == false)
        {
            Time.timeScale = 0;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }
}
