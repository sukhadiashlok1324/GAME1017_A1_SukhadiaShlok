using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Manager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float timer = 0f;
        
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval) 
        {
            SpawnObstacle();
            timer = 0f;        
        }
    }


    void SpawnObstacle()
    {
        float randomX = Random.Range(-5f, 5f);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
