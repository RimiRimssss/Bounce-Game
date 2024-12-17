using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Check if the player is on the ground

    private Vector2 moveInput; // Store the movement input

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Calculate movement direction
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    public void OnMove(Vector2 input)
    {
        // Update the movement input from the joystick
        moveInput = input;
    }

    public void Jump()
    {
        // Only allow jumping if the player is grounded
        if (isGrounded)
        {
            // Apply an upward force to the Rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Set isGrounded to false after jumping
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
        }

        if (collision.gameObject.CompareTag("SlipperyPlatform"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("DisappearingPlatform"))
        {
            isGrounded = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player is on a slippery platform
        if (other.CompareTag("SlipperyPlatform"))
        {

        }

        // Check if the player is on a disappearing platform
        if (other.CompareTag("DisappearingPlatform"))
        {

        }
    }

    public void JumpButtonPressed()
    {
        if (isGrounded)
        {
            Jump();
        }
    }
}