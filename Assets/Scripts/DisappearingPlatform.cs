using System.Collections;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float disappearDelay = 2f; // Time before the platform disappears
    public float reappearDelay = 5f; // Time before the platform reappears
    private bool isPlayerOnPlatform = false; // Track if the player is on the platform

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player stepped on the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true; // Set the flag when the player steps on the platform
            StartCoroutine(HandlePlatform()); // Start the disappearing process
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Reset the flag when the player leaves the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; // Reset the flag when the player leaves
        }
    }

    private IEnumerator HandlePlatform()
    {
        // Wait for the disappear delay
        yield return new WaitForSeconds(disappearDelay);

        // Disable the platform
        gameObject.SetActive(false);

        // Wait for the reappear delay
        yield return new WaitForSeconds(reappearDelay);

        // Re-enable the platform
        gameObject.SetActive(true);
    }
}