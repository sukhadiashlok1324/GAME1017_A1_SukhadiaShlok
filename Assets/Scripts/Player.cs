using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 10.0f;
    // Start is called before the first frame update
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
    }
}
