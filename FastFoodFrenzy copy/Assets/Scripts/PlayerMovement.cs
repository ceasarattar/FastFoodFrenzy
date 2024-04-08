using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float crouchSpeed = 6f; // Speed when crouching
    public float gravity = -9.81f;
    public float crouchHeight = 1.0f; // Height when crouching
    public float standingHeight = 2.0f; // Normal standing height
    public KeyCode crouchKey = KeyCode.C; // Key to crouch

    private Vector3 velocity;
    private bool isCrouching = false;

    void Update()
    {
        // Crouch toggle
        if (Input.GetKeyDown(crouchKey))
        {
            isCrouching = !isCrouching;
            controller.height = isCrouching ? crouchHeight : standingHeight;
            // Optionally, adjust the center of the CharacterController if needed
            // controller.center = new Vector3(controller.center.x, isCrouching ? crouchHeight / 2 : standingHeight / 2, controller.center.z);
        }

        // Adjust speed based on crouching state
        float adjustedSpeed = isCrouching ? crouchSpeed : speed;

        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * adjustedSpeed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Apply gravity
    }
}
