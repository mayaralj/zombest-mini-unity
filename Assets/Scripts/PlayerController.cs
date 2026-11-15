using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    Rigidbody rb;
    Vector3 moveDir;

    void Start()
    {
        // Store in rb the reference to the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
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
    }

    void FixedUpdate()
    {
        // Store the rigidbody's velocity from moveDir and moveSpeed
        rb.linearVelocity = moveDir * moveSpeed;
    }
}