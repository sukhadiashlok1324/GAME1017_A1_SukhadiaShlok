using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Score : MonoBehaviour
{
    public int scoreValue = 10; // Score value of this enemy

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find ScoreManager in the scene
    }

    private void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.IncrementScore(scoreValue); // Increment score when enemy is destroyed
        }
    }
}

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the projectile

            // You may also play sound effects, particle effects, etc.
        }
    }
}

