using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float speed = 10.0f;
    public float Health;
    public float rotationSpeed = 100f;
    public Transform Explosionposition;
    public GameObject ExplosionPrefab;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction -= Vector3.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        transform.position += direction.normalized * speed * Time.deltaTime;

        //Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            // AB = B - A
            Vector3 shootDirection = (mouse - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position + shootDirection, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * speed;

        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile Enemy"))   //If the enemy bullets hits player, health decreases 
        {
            Health -= 1.0f;
        }

        if (Health <= 0.0f)       
        {
            Die();
        }

        if (collision.CompareTag("Obstacle"))    // If the player hits obstacle, it dies
        {
            Die();
        }
    }




    private void Die()     
    {
        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);     //When the player is destroyed, an explosion animation is instantiated
        Destroy(gameObject);
    }
}