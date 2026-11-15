using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float lifetime = 1f;
    float timer;
    BulletPool pool;
    

    void OnEnable()
    {
        // Reset the timer to the lifetime value when the bullet is enabled
        timer = lifetime;
    }

    // Set the reference to the bullet pool
    public void SetPool(BulletPool p)
    {
        pool = p;
    }

    void Update()
    {
        // Move bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Count the timer down and at 0 or less switch the bullet off
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Return the bullet to the pool
            pool.Return(this);
        }
    }

}