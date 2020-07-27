using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextScoreRetrieval : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplayer;

    // Start is called before the first frame update
    void Start()
    {
        int score = LoadHighScore();
        scoreDisplayer.text = score.ToString();
    }

    public int LoadHighScore()
    {
        int score = PlayerPrefs.GetInt("HighScore", 0);
        return score;
    }
}
