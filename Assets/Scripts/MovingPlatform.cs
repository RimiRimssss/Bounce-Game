using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // First point
    public Transform pointB; // Second point
    public float speed = 2f; // Speed of the platform
    private Vector3 targetPosition; // Current target position

    void Start()
    {
        // Start at point A
        targetPosition = pointA.position;
    }

    void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Switch target position
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player is on the platform, move with it
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform; // Make the player a child of the platform
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player leaves the platform, unparent them
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null; // Remove the player from the platform
        }
    }
}