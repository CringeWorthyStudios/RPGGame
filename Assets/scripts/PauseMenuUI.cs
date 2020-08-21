using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{

    public bool gamePaused = false;

    public GameObject PauseMenuUI2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        PauseMenuUI2.SetActive(false);
        Time.timeScale = 1F;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        PauseMenuUI2.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
