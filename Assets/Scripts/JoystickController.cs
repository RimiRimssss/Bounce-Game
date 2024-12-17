using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform joystickBackground; // Reference to the joystick background
    public RectTransform joystickHandle; // Reference to the joystick handle
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private Vector2 inputVector; // Store the input vector

    void Start()
    {
        joystickHandle.anchoredPosition = Vector2.zero; // Center the joystick handle
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Get the position of the joystick background in screen space
        Vector2 position = RectTransformUtility.WorldToScreenPoint(Camera.main, joystickBackground.position);

        // Calculate the input vector based on the drag position
        inputVector = (eventData.position - position) / (joystickBackground.sizeDelta / 2);
        inputVector = Vector2.ClampMagnitude(inputVector, 1); // Limit the input vector to a maximum length of 1

        // Move the joystick handle
        joystickHandle.anchoredPosition = inputVector * (joystickBackground.sizeDelta / 2); // Move the handle
        playerMovement.OnMove(inputVector); // Pass the input to the PlayerMovement script
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Call OnDrag when the pointer is down
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Reset the input vector and handle position
        inputVector = Vector2.zero; // Reset the input vector
        joystickHandle.anchoredPosition = Vector2.zero; // Reset the handle position
        playerMovement.OnMove(inputVector); // Pass the reset input to the PlayerMovement script
    }
}