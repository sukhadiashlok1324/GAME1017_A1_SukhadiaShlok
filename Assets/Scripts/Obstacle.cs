using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 2f; // Speed of obstacle movement
    public float despawnDistance = 10f; // Distance at which the obstacle despawns
    public GameObject obstaclePrefab; // Prefab of the obstacle to respawn
    private Vector3 moveDirection; // Direction in which the obstacle moves
   
    void Start()
    {
        // Determine move direction based on initial position
        if (transform.position.x < 0)
        {
            // If obstacle spawned on the left side, move right
            moveDirection = Vector3.right;
        }
        else
        {
            // If obstacle spawned on the right side, move left
            moveDirection = Vector3.left;
        }
    }

    void Update()
    {
        // Move the obstacle
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Check despawn condition
        if (Mathf.Abs(transform.position.x) >= despawnDistance)
        {
            // Respawn obstacle if it goes beyond despawn distance
            RespawnObstacle();
            // Destroy the current obstacle
            Destroy(gameObject);
        }
    }

    // Respawn obstacle
    void RespawnObstacle()
    {
        // Instantiate a new obstacle at the same position
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
    }
}
