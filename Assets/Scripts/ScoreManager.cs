using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Field for high score text

    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Initialize score and high score texts
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckForHighScore();
    }

    private void UpdateScoreText()
    {
        // Update UI text to display current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void UpdateHighScoreText()
    {
        // Update UI text to display high score
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    private void CheckForHighScore()
    {
        // Check if the current score is higher than the high score
        if (score > highScore)
        {
            highScore = score;
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetInt("HighScore", highScore);
            // Update the high score text
            UpdateHighScoreText();
        }
    }
}
