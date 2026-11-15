using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float fireCooldown = 0.2f;
    [SerializeField] BulletPool bulletPool;
    [SerializeField] int maxHealth = 5;
    [SerializeField] float damageCooldown = 1f;
    int health;
    float damageTimer;
    float fireTimer = 0f;
    Rigidbody rb;
    Vector3 moveDir;

    void Start()
    {
        // Store in rb the reference to the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();

        // Set Health to maxHealth at the start of the game
        health = maxHealth;
    }

    void Update()
    {
        // PLAYER MOVEMENT/INPUT \\
        float x = 0f;
        float z = 0f;
        // Check if the player is pressing the W key
        if (Keyboard.current.wKey.isPressed)
        {
            z += 1f;
        }
        // Check if the player is pressing the S key
        if (Keyboard.current.sKey.isPressed)
        {
            z -= 1f;
        }
        // Check if the player is pressing the A key
        if (Keyboard.current.aKey.isPressed)
        {
            x -= 1f;
        }
        // Check if the player is pressing the D key
        if (Keyboard.current.dKey.isPressed)
        {
            x += 1f;
        }
        // Build the moveDir vector based on the x and z values, and normalize it to ensure consistent movement speed in all directions
        moveDir = new Vector3(x, 0, z).normalized;
        //=======================================================\\

        // PLAYER ROTATION \\
        // Make a ray from mouse position
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        // Make a plane at player height
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // If ray hit plane get hit point
        if (playerPlane.Raycast(ray, out float hitDist))
        {
            // Get the point where the ray hits the plane
            Vector3 hitPoint = ray.GetPoint(hitDist);
            
            // Get Direction from player to hit point without y axis
            Vector3 targetDir = hitPoint - transform.position;
            targetDir.y = 0f;

            // If direction isnt tiny, set rotation
            if (targetDir.sqrMagnitude > 0.001f)
            {
                // Set the rotation of the player to look at the target direction
                transform.rotation = Quaternion.LookRotation(targetDir);
            }
        }
        //=======================================================\\

        // PLAYER SHOOTING \\
        // Count down the fire timer
        fireTimer -= Time.deltaTime;

        // If the left mouse button is pressed and the fire timer is less than or equal to 0, fire a bullet
        if (Mouse.current.leftButton.isPressed && fireTimer <= 0f)
        {
            // Get a bullet from the bullet pool
            Bullet bullet = bulletPool.Get();
            if (bullet != null)
            {
                // Set the bullet's position and rotation to match the player's
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                // Reset the fire timer to the fire cooldown value
                fireTimer = fireCooldown;
            }
        }
        //=======================================================\\

        // PLAYER DAMAGE COOLDOWN \\
        // Count down the damage timer
        damageTimer -= Time.deltaTime;
        //=======================================================\\
    }

    void FixedUpdate()
    {
        // Store the rigidbody's velocity from moveDir and moveSpeed
        rb.linearVelocity = moveDir * moveSpeed;
    }

    // Handle collision with enemies
    void OnCollisionStay(Collision collision)
    {
        // If the player collides with an enemy and the damage timer is less than or equal to 0, take damage
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && damageTimer <= 0f)
        {
            // Decrease health by 1
            health--;
            Debug.Log("Player Health: " + health);

            // Reset the damage timer to the damage cooldown value
            damageTimer = damageCooldown;

            // If health is 0 or less, destroy the player GameObject
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}