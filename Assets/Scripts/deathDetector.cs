using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathDetector : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();
    public SceneLoader sceneLoader;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i].GetComponent<Billy>().IsDead)
            {
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.4f);
        sceneLoader.LoadNextScene();
    }
}
