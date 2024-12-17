using System.Collections;
using UnityEngine;

public class SlipperyPlatform : MonoBehaviour
{
    public float slipForce = 5f; // The force applied to the player to simulate slipping
    public float slipDuration = 2f; // Duration of the slipping effect

    private void OnCollisionStay(Collision collision)
    {
        // Check if the player is on the slippery platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start the slipping effect
            StartCoroutine(Slip(collision));
        }
    }

    private IEnumerator Slip(Collision playerCollision)
    {
        Rigidbody rb = playerCollision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply a continuous force in the direction the player is moving
            Vector3 slipDirection = playerCollision.transform.forward; // Get the forward direction of the player
            float elapsedTime = 0f;

            while (elapsedTime < slipDuration)
            {
                rb.AddForce(slipDirection * slipForce, ForceMode.Acceleration);
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
        }
    }
}