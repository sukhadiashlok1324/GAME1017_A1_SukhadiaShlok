using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ScriptPlayer : MonoBehaviour
{
    //public GameObject BulletPrefab;
    public float speed_ = 10f;
    public float maxDistance_ = 20f;
    public int Attackpoints;

    // Update is called once per frame
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
        if (distance >= maxDistance_)
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
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }       
       
    }
}
