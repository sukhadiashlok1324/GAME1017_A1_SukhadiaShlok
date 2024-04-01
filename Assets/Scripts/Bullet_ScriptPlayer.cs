using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ScriptPlayer : MonoBehaviour
{
    
    public float speed_ = 10f;
    public float maxDistance = 20f;
    //public int Attackpoints;

    
    void Update()
    {
        MoveBullet_();
        CheckDistance_();
    }

    void MoveBullet_()
    {
        transform.Translate(Vector2.up * speed_ * Time.deltaTime);
    }

    void CheckDistance_()
    {
        float distance = speed_ * Time.fixedDeltaTime;
        if (distance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
