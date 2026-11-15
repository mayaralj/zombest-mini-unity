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
    }

    void FixedUpdate()
    {
        // Store the rigidbody's velocity from moveDir and moveSpeed
        rb.linearVelocity = moveDir * moveSpeed;
    }
}