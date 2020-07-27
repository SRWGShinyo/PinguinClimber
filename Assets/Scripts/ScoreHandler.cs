using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler scoreHandler;
    public int score;

    public GameObject panel;
    public TextMeshProUGUI reason;
    public TextMeshProUGUI explanation;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestscoreText;
    public GameObject newBest;

    public AudioSource highScore;

    private void Awake()
    {
        scoreHandler = this;
    }

    private void Start()
    {
        score = LoadHighScore();
    }

    public void setUpFinalScore(string reason, string explanation, int score)
    {
        this.reason.text = reason;
        this.explanation.text = explanation;
        this.scoreText.text = score.ToString();

        if (score > this.score)
        {
            this.score = score;
            newBest.transform.DOScale(1f, 1f);
            SaveHighScore();
            highScore.Play();
        }

        bestscoreText.text = this.score.ToString();

        panel.SetActive(true);
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

    public int LoadHighScore()
    {
        int score = PlayerPrefs.GetInt("HighScore", 0);
        return score;
    }
}
