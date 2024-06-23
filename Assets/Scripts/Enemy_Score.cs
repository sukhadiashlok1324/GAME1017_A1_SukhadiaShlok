using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Score : MonoBehaviour
{
    public int scoreValue = 10; 
    private ScoreManager scoreManager;
    private SpriteRenderer spriteRenderer;
    private bool scoreUpdated = false;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); 
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Update()
    {
        
        if (spriteRenderer != null && !spriteRenderer.enabled && !scoreUpdated)
        {
            if (scoreManager != null)
            {
                scoreManager.IncrementScore(scoreValue); 
                scoreUpdated = true; 
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
                enemySpriteRenderer.enabled = false; 
            }
            Destroy(gameObject); 
        }
    }
}
