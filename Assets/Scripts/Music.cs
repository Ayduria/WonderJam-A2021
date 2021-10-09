using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    public AudioMixer audioMixer;
    private AudioSource _audioSource;
    private float volume;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("volume", 0.75f);
    }

    public void PlayMusic()
    {
        audioMixer.SetFloat("MainVol", Mathf.Log10(volume) * 20);
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
