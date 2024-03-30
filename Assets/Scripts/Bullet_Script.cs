using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    //public GameObject BulletPrefab;
    public float speed = 10f;
    public float maxDistance = 20f;
    public int Attackpoints;

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
        CheckDistance();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void CheckDistance()
    {
        float distance = speed * Time.fixedDeltaTime;
        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Damagable target = collision.GetComponent<Damagable>();
        if (target != null)
        {
            return;
        }
        target.TakeDamage(Attackpoints);*/
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
