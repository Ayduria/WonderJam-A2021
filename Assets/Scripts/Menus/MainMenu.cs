using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;

    public void PlayGame()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        sceneLoader.LoadNextScene();
    }

    public void HowToPlay()
    {
        sceneLoader.LoadIndexScene(6);
    }

    public void SettingsMenu()
    {
        sceneLoader.LoadIndexScene(7);
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
