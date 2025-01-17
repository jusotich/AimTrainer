using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetBehavior : MonoBehaviour
{
    public float health;
    public int scoreGiven;   // Variable to hold the specific score for each target type

    // Method to take damage
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Called when health reaches zero or below
    void Die()
    {
        // Notify the spawner to update target count
        TargetSpawner spawner = FindAnyObjectByType<TargetSpawner>();
        if (spawner != null)
        {
            spawner.TargetDestroyed();   // Notify spawner that a target was destroyed
        }

        // Destroy the target object
        Destroy(gameObject);
    }

    // This method is called when the target is destroyed
    void OnDestroy()
    {
        // Find the ScoreManager to update the score
        scoreManger scoreManager = FindFirstObjectByType<scoreManger>();
        if (scoreManager != null)
        {
            // Add score based on the target's specific score value
            scoreManager.AddScore(scoreGiven);
        }
        else
        {
            Debug.LogError("ScoreManager not found! Ensure there is a ScoreManager in the scene.");
        }
    }
}
