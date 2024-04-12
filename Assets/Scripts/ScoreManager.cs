using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    

    private int score = 0;
    

    private void Start()
    {
        // Initialize score text
        UpdateScoreText();
        
    }

    

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();

    }

    

    private void UpdateScoreText()
    {
        // Update UI text to display current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
