using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public scoreManger scoreManger;
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
        scoreManger.currentScore += 10;
    }
}
