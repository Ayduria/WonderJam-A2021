using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneSkip : MonoBehaviour
{
    public SceneLoader sceneLoader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            sceneLoader.LoadNextScene();
        }
    }
}
