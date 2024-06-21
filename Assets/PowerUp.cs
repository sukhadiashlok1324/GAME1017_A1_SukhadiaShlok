using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjustable speed in Inspector
    public float enlargeScale = 1.5f; // Scale factor when colliding with player
    public float enlargeTime = 0.5f; // Time to stay enlarged before returning to original size
    public float returnSpeed = 2f; // Speed to return to original size
    public GameObject explosionPrefab; // Assign explosion prefab in Inspector
    public float explosionScaleMultiplier = 2f; // Multiplier for explosion prefab scale

    private Vector3 originalScale;
    private bool isEnlarged = false;
    private bool returningToOriginalSize = false;
    private Vector3 centerPosition;

    void Start()
    {
        originalScale = transform.localScale;
        centerPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f)); // Center of the screen (Z = 10)
    }

    void Update()
    {
        // Move downward
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Check if returning to original size
        if (returningToOriginalSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, returnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.localScale, originalScale) < 0.01f)
            {
                transform.localScale = originalScale;
                returningToOriginalSize = false;

                // Move towards center of the screen
                MoveToCenter();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isEnlarged)
            {
                isEnlarged = true;
                transform.localScale *= enlargeScale;
                Invoke(nameof(ReturnToOriginalSize), enlargeTime);
            }
        }
    }

    private void ReturnToOriginalSize()
    {
        // Start returning to original size
        isEnlarged = false;
        returningToOriginalSize = true;
    }

    private void MoveToCenter()
    {
        // Move towards center of the screen
        transform.position = Vector3.MoveTowards(transform.position, centerPosition, moveSpeed * Time.deltaTime);

        // Check if reached center
        if (transform.position == centerPosition)
        {
            // Calculate explosion scale
            Vector3 explosionScale = explosionPrefab.transform.localScale * explosionScaleMultiplier;

            // Instantiate explosion prefab with adjusted scale
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosion.transform.localScale = explosionScale;

            // Destroy all enemies
            DestroyAllEnemies();
        }
    }

    private void DestroyAllEnemies()
    {
        // Find all enemy GameObjects in the scene and destroy them
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
