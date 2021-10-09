using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Toggle fullScreenToggle;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        LoadSettings();
        fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
    }

    private void LoadSettings()
    {
        fullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) > 0;
        volumeSlider.value = PlayerPrefs.GetFloat("volume", 0.75f);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("FullScreen", isFullscreen ? 1 : 0);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("MainVol", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);
    }
}
