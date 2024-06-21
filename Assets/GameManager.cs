using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnEnemyWithDelay(GameObject enemyPrefab, Vector3 position, Quaternion rotation, float delay)
    {
        StartCoroutine(SpawnEnemyCoroutine(enemyPrefab, position, rotation, delay));
    }

    private IEnumerator SpawnEnemyCoroutine(GameObject enemyPrefab, Vector3 position, Quaternion rotation, float delay)
    {
        Debug.Log("Coroutine started, waiting for " + delay + " seconds.");
        yield return new WaitForSeconds(delay);
        Debug.Log("Coroutine finished waiting, now calling Instantiate for EnemyPrefab.");
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, position, rotation);
        }
        else
        {
            Debug.LogError("EnemyPrefab is null when trying to instantiate.");
        }
    }
}
