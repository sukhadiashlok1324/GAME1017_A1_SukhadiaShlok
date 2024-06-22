using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPowerScript : MonoBehaviour
{
    public GameObject powerupPrefab;
    private float dropChance = 0.1f;

    void Start()
    {
        OnDestroy();
    }

    private void OnDestroy()
    {
        if (Random.value > dropChance)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                DropPowerup();
                Debug.Log("Player is in the scene.");
            }
            else
            {
                Debug.Log("Player is not in the scene.");
            }
        }
    }

    private void DropPowerup()
    {
        Instantiate(powerupPrefab, transform.position, Quaternion.identity);
        SpriteRenderer renderer = powerupPrefab.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found on powerupPrefab.");
        }
    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
