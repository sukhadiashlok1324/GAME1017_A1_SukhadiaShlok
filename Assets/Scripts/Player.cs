using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //public GameObject projectilePrefab;
    public TextMeshProUGUI Hitpoints;
    public float speed = 10.0f;
    public float Health = 100.0f;
    public float rotationSpeed = 100f;
    public Transform Explosionposition;
    public GameObject ExplosionPrefab;

    public void ChangeHitPoints()
    {
        Hitpoints.text = "HitPoints: " + Health; 
    }
   
    // Update is called once per frame
    void Update()
    {
        ChangeHitPoints();

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
            Health -= 10.0f;
        }

        if (collision.CompareTag("Obstacle"))    // If the player hits obstacle, Health Decreases by 2 
        {
            Health -= 20.0f;
        }

        if (collision.CompareTag("Enemy"))    // If the player hits enemy, Health decreases by 2
        {
            Health -= 20.0f;
        }
        
        if (collision.CompareTag("Health"))    // If the player hits enemy, Health decreases by 2
        {
            Health += 20.0f;
        }

        if (Health <= 0.0f)       
        {
            Health = 0.0f;
            Die();
        }

    }




    public void Die()
    {
        ChangeHitPoints();

        // Disable components to make the object inactive and invisible
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        // Add more lines to disable other components as needed

        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);

        // Delay the scene change
        Invoke("LoadSceneAfterDelay", 1f);
    }

    private void LoadSceneAfterDelay()
    {
        SceneManager.LoadScene("After Die");
        Destroy(gameObject);
    }


}