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

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

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

        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewportPosition.x > 1)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(0, viewportPosition.y, viewportPosition.z)).x;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = mainCamera.ViewportToWorldPoint(new Vector3(1, viewportPosition.y, viewportPosition.z)).x;
        }

        
        float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, viewportPosition.z)).y;
        float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, viewportPosition.z)).y;

        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile Enemy"))   
        {
            Health -= 10.0f;
        }

        if (collision.CompareTag("Obstacle")) 
        {
            Health -= 20.0f;
        }

        if (collision.CompareTag("Enemy"))    
        {
            Health -= 20.0f;
        }

        if (collision.CompareTag("Health"))
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

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        Instantiate(ExplosionPrefab, Explosionposition.position, Quaternion.identity);

        
        Invoke("LoadSceneAfterDelay", 1f);
    }

    private void LoadSceneAfterDelay()
    {
        SceneManager.LoadScene("After Die");
        Destroy(gameObject);
    }
}
