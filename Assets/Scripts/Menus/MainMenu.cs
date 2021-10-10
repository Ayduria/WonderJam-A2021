using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public AudioMixer audioMixer;
    private float volume;

    private void Awake()
    {
        volume = PlayerPrefs.GetFloat("volume", 0.75f);
    }

    private void Start()
    {
        audioMixer.SetFloat("MainVol", Mathf.Log10(volume) * 20);
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

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
