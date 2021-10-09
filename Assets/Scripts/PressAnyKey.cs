using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
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
