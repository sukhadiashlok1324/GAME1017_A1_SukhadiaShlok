using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public float speed = 5f;
    public float destroyY = -10f;

    // Update is called once per frame
    void Update()
    {
        Move();
        Checkdestroy();
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Checkdestroy()
    {

        if (transform.position.y <= destroyY) 
        { 
            Destroy(gameObject);        
        }
    }

}
