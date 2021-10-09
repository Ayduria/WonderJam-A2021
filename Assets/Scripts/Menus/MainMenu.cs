using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public void PlayGame()
    {
        sceneLoader.LoadNextScene();
    }

    public void HowToPlay()
    {
        sceneLoader.LoadIndexScene(4);
    }

    public void SettingsMenu()
    {
        sceneLoader.LoadIndexScene(5);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
