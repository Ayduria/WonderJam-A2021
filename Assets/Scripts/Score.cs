using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue;
    public static int highScore;
    public Text score;
    public Text timer;
    private float timerScore;
    private int multiplier = 1;
    private float time;
    private float minutes = 0;
    private float seconds = 0;
    private float miliseconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0;
        score.text = "SCORE: " + scoreValue + " x " + multiplier;
        highScore = PlayerPrefs.GetInt("bestScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timerScore += Time.deltaTime;

        time += Time.deltaTime;
        miliseconds = (int)((time - (int)time) * 100);
        seconds = (int)(time % 60);
        minutes = (int)(time / 60 % 60);

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, (int)miliseconds);
        PlayerPrefs.SetString("playerTime", timer.text);

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.E))
        {
            multiplier = 1;
            score.text = "SCORE: " + scoreValue + " x " + multiplier;
        }

        if (timerScore > 1f)
        {
            multiplier += 1;
            scoreValue += 50 * multiplier;
            score.text = "SCORE: " + scoreValue + " x " + multiplier;
            PlayerPrefs.SetInt("playerScore", scoreValue);
            if (scoreValue > highScore)
            {
                PlayerPrefs.SetInt("bestScore", scoreValue);
            }
            timerScore = 0;
        }
    }
}
