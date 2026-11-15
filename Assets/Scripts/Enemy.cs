using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] int health = 3;
    [SerializeField] Transform target;
    Rigidbody rb;
    EnemySpawner spawner;

    void Start()
    {
        // Rigidbody in rb
        rb = GetComponent<Rigidbody>();
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    public void SetSpawner(EnemySpawner s)
    {
        spawner = s;
    }

    void FixedUpdate()
    {
        // If game over, stop moving
        if (GameManager.Instance.gameOver)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        
        // if target is null, return
        if (target == null)
        {
            return;
        }

        // Get the direction to the target, flattened and normalized
        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        // Set the velocity of the rigidbody to move towards the target
        rb.linearVelocity = direction * speed;
    }

    public void TakeDamage(int amount)
    {
        // Take damage and check if health is 0 or less, if so destroy the enemy
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
            // Notify the spawner that this enemy has been destroyed
            if (spawner != null)
            {
                // Notify game manager that the enemy has been destroyed and we add score
                GameManager.Instance.AddScore(1);
                spawner.EnemyDestroyed();
            }
        }
    }
}