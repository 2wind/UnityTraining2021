using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{


    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    public static int highscore = 1000;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            highscore = PlayerPrefs.GetInt("ApplePickerHighScore");
        }
        PlayerPrefs.SetInt("ApplePickerHighScore", highscore);
    }



    void OnEnable()
    {
        scoreText.text = score.ToString();
        Basket.OnCatch += IncreaseScore;

        Apple.OnDestroy += DecreaseScore;
    }

    // Update is called once per frame
    void OnDisable()
    {
        Basket.OnCatch -= IncreaseScore;
        Apple.OnDestroy -= DecreaseScore;
    }

    private void DecreaseScore()
    {
        score -= 150;
        UpdateDisplay();
    }

    void IncreaseScore()
    {
        score += 100;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("ApplePickerHighScore", highscore);
        }
        scoreText.text = score.ToString();
        highscoreText.text = "High Score: " + highscore.ToString();

    }


}
