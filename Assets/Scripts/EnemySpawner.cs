using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform player;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnRadius = 25f;
    float spawnTimer;
    int currentEnemies = 0;
    int maxEnemies = 2;

    void Update()
    {
        // Count the spawn timer down
        spawnTimer -= Time.deltaTime;
        // If the timer is 0 or less, spawn an enemy and reset the timer
        if (spawnTimer <= 0 && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    public void EnemyDestroyed()
    {
        // Decrease the current enemy count when an enemy is destroyed
        currentEnemies--;
    }

    void SpawnEnemy()
    {
        // Pick a random angle
        float angle = Random.Range(0f, 2f * Mathf.PI);

        // Calculate the offset from the player using the angle and spawn radius
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius;

        // Calculate the spawn position by adding the offset to the player's position
        Vector3 position = player.position + offset;

        // Instantiate the enemy prefab at the calculated position and set its target to the player
        Enemy enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
        currentEnemies++;
        enemy.SetSpawner(this);
        enemy.SetTarget(player);
    }
}