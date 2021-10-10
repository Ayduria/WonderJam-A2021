using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameplay : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private void OnEnable()
    {
        sceneLoader.LoadNextScene();
    }

}
