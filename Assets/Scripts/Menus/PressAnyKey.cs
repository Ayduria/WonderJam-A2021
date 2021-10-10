using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
