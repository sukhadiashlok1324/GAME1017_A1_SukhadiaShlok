using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float speed = 10f; // meters/seconds
    public float maxDistance = 20f; // meters
    float distance = 0; // meters
    public Vector2 direction;
    //public Transform rotation;

    //public GameObject HitSound;

    // Update is called once per frame, maybe 60 times per second? Maybe 100? Maybe 400?
    void Update()
    {
        MoveBullet();
        CheckDistance(); // adds 1 to distance
    }

    void MoveBullet()
    {
        //speed -> meters/seconds
        //Time.deltaTime -> seconds\
        //Translate(Vector2(metersX/seconds * seconds, metersY/seconds * seconds) 

        float distanceToTravel = speed * Time.deltaTime;
        Vector2 displacement = direction * distanceToTravel;
        distance = distance + distanceToTravel;
        transform.Translate(displacement);
    }

    void CheckDistance() 
    {
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
