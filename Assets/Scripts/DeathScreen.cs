using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public Text lastScore;
    public Text lastTime;
    public Text bestScore;

    // Start is called before the first frame update
    void Start()
    {
        lastScore.text = "SCORE: " + PlayerPrefs.GetInt("playerScore", 0);
        bestScore.text = "MEILLEUR: " + PlayerPrefs.GetInt("bestScore", 0);
        lastTime.text = "TIME: " + PlayerPrefs.GetString("playerTime", "00:00:00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        sceneLoader.LoadIndexScene(4);
    }

    public void BackToMenu()
    {
        sceneLoader.LoadIndexScene(2);
    }
}
