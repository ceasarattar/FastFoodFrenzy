using UnityEditor;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator; // Add a reference to the Animator component
    public float speed = 12f;
    public float runMultiplier = 1.5f; // Multiplier for running speed
    public float gravity = -9.81f;
    public float standingHeight = 2.0f;
    public KeyCode runKey = KeyCode.LeftShift; // Key to run

    private Vector3 velocity;
    private bool isRunning = false;

    void Update()
    {
        // Check if the run key is held down
        isRunning = Input.GetKey(runKey);

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // Determine if the player is moving forward or backward
        bool isMovingBackward = z < 0;
        
        Vector3 move = transform.right * x + transform.forward * z;
        float currentSpeed = speed;
        if (isRunning)
        {
            currentSpeed *= runMultiplier;
        }
        
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Set the Animator parameters
        animator.SetFloat("Speed", Mathf.Abs(z));
        animator.SetBool("IsMovingBackward", isMovingBackward);
        animator.SetBool("IsRunning", isRunning);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Apply gravity
    } 
}
