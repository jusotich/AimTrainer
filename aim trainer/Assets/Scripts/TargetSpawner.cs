using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int maxTargets = 5;
    public float spawnInterval = 2f;
    public Vector3 spawnArea = new Vector3(10f, 5f, 10f);

    private int currentTargetCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start spawning targets
        InvokeRepeating(nameof(SpawnTarget), 0f, spawnInterval);
        OnDrawGizmos();
    }

    void SpawnTarget()
    {
        if (currentTargetCount >= maxTargets) return; // Limit the number of targets

        // Randomize spawn position within the spawn area
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            Random.Range(-spawnArea.y / 2, spawnArea.y / 2),
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        // Spawn the target and increase the count
        Instantiate(targetPrefab,transform.position + spawnPos, Quaternion.identity,transform);
        currentTargetCount++;
    }

    public void TargetDestroyed()
    {
        currentTargetCount--; // Decrease the count when a target is destroyed
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}
