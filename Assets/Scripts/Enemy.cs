using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject HealthPrefab;
    public GameObject EnemyPrefab;
    public float movementspeed = 2f;
    public float shootingInterval = 1f;
    public float bulletspeed = 3f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float health = 4.0f;
    public Transform Explosionposition;
    public GameObject ExplosionPrefab;
    public float DestroyDelay = 2f;

    private bool Shoot_ = true;
    private float nextShootTime;
    private Rigidbody2D rb;
    private bool movingRight = true;

    public ScoreManager scoreManager; // Reference to the ScoreManager
    private int lastCheckedScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextShootTime = Time.time + shootingInterval;

        if (scoreManager == null)
        {
            // Find the ScoreManager in the scene if it's not assigned in the inspector
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        if (scoreManager != null)
        {
            lastCheckedScore = scoreManager.GetScore();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
            rb.velocity = new Vector2(movementspeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-movementspeed, rb.velocity.y);

        if (transform.position.x >= 5f)
            movingRight = false;
        else if (transform.position.x <= -5f)
            movingRight = true;

        if (Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + shootingInterval;
        }

        if (scoreManager != null)
        {
            int currentScore = scoreManager.GetScore();

            // Check if the score is a multiple of 50 and has increased since last checked
            if (currentScore > lastCheckedScore && currentScore % 50 == 0)
            {
                SpawnPrefabIfNoneExist();
            }

            lastCheckedScore = currentScore;
        }
    }

    void Shoot()
    {
        if (Shoot_)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bulletPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletspeed;
        }
    }

    private UnityEvent OnDieEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Projectile"))
        {
            health -= 1.0f;
        }

        if (health <= 0.0)
        {
            Die();
        }
    }

    private void SpawnPrefab()
    {       
        Instantiate(HealthPrefab, Explosionposition);
    }

    private void SpawnPrefabIfNoneExist()
    {
        if (GameObject.FindWithTag("Health") == null)
        {
            if (HealthPrefab != null)
            {
                GameObject newObject = Instantiate(HealthPrefab, Explosionposition);
                newObject.tag = "Health";
                newObject.transform.parent = null;
                //Debug.Log("Spawning Prefab");
            }
            else
            {
                //Debug.LogError("Prefab to spawn is not assigned!");
            }
        }
        else
        {
            //Debug.Log("A GameObject with the tag 'Health' already exists.");
        }
    }

        void Die()
    {
        Shoot_ = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("EnemyNew", DestroyDelay);
        Invoke("AfterDie", 2f);
        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);
    }

    void EnemyNew()
    {
        GameObject newEnemy = Instantiate(EnemyPrefab, Explosionposition.position, Quaternion.identity);
        newEnemy.transform.SetParent(null);
        SpriteRenderer renderer = newEnemy.GetComponent<SpriteRenderer>(); 
        if (renderer != null)
        {
            renderer.enabled = true; 
        }
        CircleCollider2D collider2D = newEnemy.GetComponent<CircleCollider2D>(); 
        if (collider2D != null)
        {
            collider2D.enabled = true; 
        }
    }

    void AfterDie()
    {
        Destroy(gameObject);
    }
}
