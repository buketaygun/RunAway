using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    Vector3 velocity;
    public float forwardSpeed = 5f;
    int line = 1;
    public float range = 3f;
    public float jumpForce = 8f;
    public float gravity = -10f;
    private bool isFalling = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }

    void Update()
    {
        // Handle input and movement
        HandleInput();

        // Check for obstacles if falling
        if (isFalling)
        {
            CheckObstacle();
        }

        // Move the player
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleInput()
    {
        // Set the forward movement
        velocity.z = forwardSpeed;

        // Jumping
        if (characterController.isGrounded)
        {
            velocity.y = -1;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                velocity.y = jumpForce;
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            isFalling = true;
        }

        // Horizontal movement (left and right)
        float horizontalInput = Input.GetAxis("Horizontal");
        velocity.x = horizontalInput * forwardSpeed;

        // Line movement
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            line++;
            if (line == 3)
            {
                line = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            line--;
            if (line == -1)
            {
                line = 0;
            }
        }

        // Directly set the target line position
        float targetLineZ = line * range;

        // Update the position after moving the player to prevent falling off
        transform.position = new Vector3(transform.position.x, transform.position.y, targetLineZ);

        // Move the player based on velocity
        characterController.Move(velocity * Time.deltaTime);
    }


    void CheckObstacle()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, characterController.height / 2 + 0.1f))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Hit an obstacle!");
                GameOver();
            }
        }
    }

    void GameOver()
    {
        // Add your game over logic here
        GameControl.gameOver = true;
        Debug.Log("Game Over!");
    }
}




