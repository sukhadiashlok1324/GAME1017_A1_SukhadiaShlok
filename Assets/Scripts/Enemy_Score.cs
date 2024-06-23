using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Score : MonoBehaviour
{
    public int scoreValue = 10; // Score value of this enemy
    private ScoreManager scoreManager;
    private SpriteRenderer spriteRenderer;
    private bool scoreUpdated = false;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find ScoreManager in the scene
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }

    private void Update()
    {
        // Check if the SpriteRenderer is inactive and the score has not been updated yet
        if (spriteRenderer != null && !spriteRenderer.enabled && !scoreUpdated)
        {
            if (scoreManager != null)
            {
                scoreManager.IncrementScore(scoreValue); // Increment score
                scoreUpdated = true; // Prevent multiple increments
            }
        }
    }
}


public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SpriteRenderer enemySpriteRenderer = other.GetComponent<SpriteRenderer>();
            if (enemySpriteRenderer != null)
            {
                enemySpriteRenderer.enabled = false; // Deactivate the enemy's SpriteRenderer
            }
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
