using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    Resolution[] resolutions;
    Resolution selectedResolution;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        LoadSettings();
        CreateResolutionDropdown();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
        fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
    }

    private void LoadSettings()
    {
        selectedResolution = new Resolution();
        selectedResolution.width = PlayerPrefs.GetInt("ResolutionWidth", Screen.currentResolution.width);
        selectedResolution.height = PlayerPrefs.GetInt("ResolutionHeight", Screen.currentResolution.height);
        fullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) > 0;
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullScreenToggle.isOn);
    }

    public void CreateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Mathf.Approximately(resolutions[i].width, selectedResolution.width) && Mathf.Approximately(resolutions[i].height, selectedResolution.height))
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionWidth", selectedResolution.width);
        PlayerPrefs.SetInt("ResolutionHeight", selectedResolution.height);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("FullScreen", isFullscreen ? 1 : 0);
    }
}
