using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetBehavior : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        TargetSpawner spawner = FindAnyObjectByType<TargetSpawner>();
        if (spawner != null)
        {
            spawner.TargetDestroyed();
        }
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        // Notify the ScoreManager when this object is destroyed
        scoreManger scoreManager = FindFirstObjectByType<scoreManger>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(10); // Add score when destroyed
        }
        else
        {
            Debug.LogError("ScoreManager not found!");
        }
    }
}
