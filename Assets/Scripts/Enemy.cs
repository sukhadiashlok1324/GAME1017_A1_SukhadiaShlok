using UnityEngine;

void AfterDestroy()
{
    // Check if there are no enemies present before spawning a new one
    GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

    if (remainingEnemies.Length == 0)
    {
        Debug.Log("No enemies present, spawning new enemy after delay.");
        StartCoroutine(SpawnNewEnemyAfterDelay());
    }
    else
    {
        Debug.Log("Enemies still present, not spawning new enemy.");
    }
}

IEnumerator SpawnNewEnemyAfterDelay()
{
    yield return new WaitForSeconds(DestroyDelay);
    Debug.Log("Spawning new enemy.");
    SpawnNewEnemy();
}

void SpawnNewEnemy()
{
    if (EnemyPrefab == null)
    {
        Debug.LogError("EnemyPrefab is not assigned!");
        return;
    }

    if (Explosionposition == null)
    {
        Debug.LogError("Explosionposition is not assigned!");
        return;
    }

    Instantiate(EnemyPrefab, Explosionposition.position, Explosionposition.rotation);
}
