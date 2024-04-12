using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float speed = 10.0f;
    public float Health = 7.0f;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile Enemy"))   //If the enemy bullets hits player, health decreases 
        {
            Health -= 1.0f;
        }

        if (collision.CompareTag("Obstacle"))    // If the player hits obstacle, Health Decreases by 2 
        {
            Health -= 2.0f;
        }

        if (collision.CompareTag("Enemy"))    // If the player hits enemy, Health decreases by 2
        {
            Health -= 2.0f;
        }

        if (Health <= 0.0f)       
        {
            Die();
        }

    }




    public void Die()     
    {
        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);     //When the player is destroyed, an explosion animation is instantiated
        Destroy(gameObject);
        
    }
}