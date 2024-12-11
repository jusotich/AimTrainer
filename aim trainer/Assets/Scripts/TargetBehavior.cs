using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    public float health = 10f;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
        TargetSpawner spawner = FindObjectOfType<TargetSpawner>();
        if (spawner != null)
        {
            spawner.TargetDestroyed();
        }
        Destroy(gameObject);
    }
}
