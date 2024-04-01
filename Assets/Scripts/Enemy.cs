using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float movementspeed = 2f;
    public float shootingInterval = 1f;
    public float bulletspeed = 3f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float health = 4.0f;
    public Transform Explosionposition;
    public GameObject ExplosionPrefab;
    
    private float nextShootTime;
    private Rigidbody2D rb;
    private bool movingRight = true;
    //private int Scorebounty = 10;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        nextShootTime = Time.time + shootingInterval;
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
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bulletPrefab.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletspeed;
    }

    private UnityEvent OnDieEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            health -= 1.0f;
        }

        if (health <= 0.0)
        {
            Die();
        }
    }



    void Die()
    {
        
        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
