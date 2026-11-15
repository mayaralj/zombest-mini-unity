using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] int poolSize = 30;
    Queue<Bullet> pool = new Queue<Bullet>();

    void Awake()
    {
        // Build up the pool of bullets
        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            // Switch it off
            bullet.gameObject.SetActive(false);

            // Add it to the pool
            pool.Enqueue(bullet);

            // Set the reference to this pool in the bullet
            bullet.SetPool(this);
        }
    }

    public Bullet Get()
    {
        // TODO 2: if the queue is empty return null; else dequeue, switch on, return it
        if (pool.Count == 0)
        {
            return null;
        }
        Bullet bullet = pool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void Return(Bullet bullet)
    {
        // Put it back in the pool and switch it off
        bullet.gameObject.SetActive(false);
        pool.Enqueue(bullet);
    }
}