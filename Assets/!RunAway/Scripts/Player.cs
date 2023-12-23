using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    CharacterController characterController;
    Vector3 vector3;
    public float forwardSpeed;
    int line = 1;
    public float range = 3;
    public float jumpF;
    public float gravity = -10;
    



    
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        vector3 = transform.position;

        
    }

    
    void Update()
    {
        vector3.z = forwardSpeed;

        if (characterController.isGrounded)
        {
            vector3.y = -1;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                vector3.y = jumpF;
            }
        }
        else
        {
            vector3.y += gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            line++;
        {
            if (line == 3)
            {
                line = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            line--;
        {
            if (line == -1)
            {
                line = 0;
            }
        }

        Vector3 targetLine = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (line == 0)
        {
            targetLine += Vector3.left * range;
        }
        if (line == 2)
        {
            targetLine += Vector3.right * range;
        }

        transform.position = targetLine;

    }

    private void FixedUpdate()
    {
       
        Vector3 move = new Vector3(0,0,forwardSpeed);
        characterController.Move(vector3 * Time.deltaTime);



    }

    private void OnControllerColliderHit(ControllerColliderHit colliderHit)
    {
        if (colliderHit.transform.tag == "Obstacle")
        {
            GameControl.gameOver = true;

        }
    }

}
