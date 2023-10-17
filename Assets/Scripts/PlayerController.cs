
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust the move speed as needed
    public bool HasPowerUp = false;

    void Update()
    {
        // Check for player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply movement to the player's position
        transform.Translate(movement);

        // Check if the player has picked up a power-up (you can implement this logic separately)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HasPowerUp = true;
            // Implement power-up behavior here
        }
    }
}

