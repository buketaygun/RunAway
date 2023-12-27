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
     
        HandleInput();

    
        if (isFalling)
        {
            CheckObstacle();
            if (transform.position.y <0) 
            {

                GameOver();
            }
        }


        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleInput()
    {

        velocity.z = forwardSpeed;

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

    
        float horizontalInput = Input.GetAxis("Horizontal");
        velocity.x = horizontalInput * forwardSpeed;


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

        float targetLineZ = line * range;

        transform.position = new Vector3(transform.position.x, transform.position.y, targetLineZ);


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
            else if (hit.collider.CompareTag("Coin"))
            {

                Destroy(hit.collider.gameObject);
            }
        }
        
        
          
        
    }

    void GameOver()
    {

        GameControl.gameOver = true;
        Debug.Log("Game Over!");
    }
}




