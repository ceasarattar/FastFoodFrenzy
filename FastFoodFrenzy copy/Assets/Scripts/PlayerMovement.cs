using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator; // Reference to the Animator component
    public float speed = 12f;
    public float crouchSpeedMultiplier = 0.5f; // Speed when crouching
    public KeyCode crouchKey = KeyCode.C; // Key to crouch
    public float gravity = -9.81f;
    public float crouchHeight = 0.5f; // Adjust if necessary
    public float standingHeight = 2.0f; // Adjust if necessary

    private Vector3 velocity;
    private bool isCrouching = false;

    void Update()
    {
        // Check for crouch input
        if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = !isCrouching;
            // Optionally, smoothly transition height if necessary
            controller.height = isCrouching ? crouchHeight : standingHeight;
        }
        
        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate adjusted speed and movement direction
        float adjustedSpeed = isCrouching ? speed * crouchSpeedMultiplier : speed;
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply movement
        controller.Move(move * adjustedSpeed * Time.deltaTime);

        // Set the Animator parameters
        animator.SetFloat("Speed", isCrouching ? move.magnitude * crouchSpeedMultiplier : move.magnitude);
        animator.SetBool("IsCrouching", isCrouching);

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    } 
}
