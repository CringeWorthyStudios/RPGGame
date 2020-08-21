using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject disableUI;
    public GameObject toggleUI;
    public GameObject AnyKeyScene;
    public GameObject AnyKeySceneNext;
    public string LoadScene = "GameScene";

    public Toggle fullscreenToggle;
    public Dropdown qualityDropdown;

    public void Start()
    {
        Debug.Log("Starting Game Main Menu");

        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;

        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }

        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("quality", 3);
            QualitySettings.SetQualityLevel(3);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }

        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();

    }

    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SavePlayerPrefs()
    {

        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }

        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        //PlayerPrefs.SetInt("quality", qualityDropdown.value);

        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.GetInt("fullscreen") == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }

        qualityDropdown.value = PlayerPrefs.GetInt("quality");
    }

    public void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 100, 90), "Testing Box");

        if (GUI.Button(new Rect(20, 40, 80, 20), "Press me"))
        {
            disableUI.SetActive(false);
            Debug.Log("Press me button got pressed");
        }

        if (GUI.Button(new Rect(20, 70, 80, 20), "Quit Game"))
        {
            QuitGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(LoadScene);
    }

    public void MenuLoaded()
    {
        AnyKeyScene.SetActive(false);
        AnyKeySceneNext.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (toggleUI.activeSelf)
            {
                toggleUI.SetActive(false);
            }
            else
            {
                toggleUI.SetActive(true);
            }
        }

        if (AnyKeyScene.activeSelf == true)
        {
            if (Input.anyKey)
            {
                MenuLoaded();
            }
        }
    }


}
