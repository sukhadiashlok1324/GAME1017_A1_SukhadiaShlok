using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject projectilePrefab;
    float speed = 10.0f;
    public float Health;
    void Start()
    {

    }

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
        transform.position += direction.normalized * speed * Time.deltaTime;

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // AB = B - A
            Vector3 shootDirection = (mouse - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position + shootDirection, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = shootDirection * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile Enemy"))
        {
            Health -= 1.0f;
        }

        if (Health <= 0.0f)
            Destroy(gameObject);

    }
}