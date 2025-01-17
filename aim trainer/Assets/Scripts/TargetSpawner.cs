using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] targetPrefab;   // Array of target prefabs to spawn
    public int maxTargets = 10;         // Maximum number of targets that can be spawned
    public float spawnInterval = 2f;    // Time interval for spawning targets
    public Vector3 spawnArea = new Vector3(10f, 5f, 10f);  // Spawn area for random position

    private int currentTargetCount = 0;  // Keeps track of the number of currently active targets

    void Start()
    {
        // Start the spawn cycle
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);  // Spawns a target every spawnInterval seconds
    }

    void SpawnTarget()
    {
        // Only spawn if current target count is less than the max target count
        if (currentTargetCount >= maxTargets) return;

        // Randomize the spawn position within the specified spawn area
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        // Cycle through the target prefabs using the index
        int index = Random.Range(0, targetPrefab.Length);  // Randomly pick a prefab from the array
        Instantiate(targetPrefab[index], transform.position + spawnPos, Quaternion.identity);

        currentTargetCount++;  // Increase the active target count
    }

    // Method called when a target is destroyed
    public void TargetDestroyed()
    {
        currentTargetCount--;  // Decrease the count when a target is destroyed
    }

    // Visualize the spawn area in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);  // Display the spawn area in the scene view
    }
}
