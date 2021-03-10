using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedUp;
    public bool right = true, doubleJump = true, grounded = true;
    public GameObject playerAssets;
    private float runSpeed = 1.3F, jumpSpeed = 8.0F, speed = 6F, gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") == 1 && right == false)
        {
            right = true;
            playerAssets.transform.Rotate(0, 180, 0, Space.Self);
        }
        else if (Input.GetAxis("Horizontal") == -1 && right == true)
        {
            right = false;
            playerAssets.transform.Rotate(0, -180, 0, Space.Self);
        }

        if (controller.isGrounded && Input.GetButton("left shift"))
        {
            doubleJump = true;
            grounded = true;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * runSpeed * speedUp;
        }
        else if (controller.isGrounded)
        {
            doubleJump = true;
            grounded = true;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * speedUp;
        }

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            moveDirection.y = jumpSpeed;
            grounded = false;
            Debug.Log(grounded);
        }
        else if (Input.GetButtonDown("Jump") && grounded == false && doubleJump == true)
        {
            moveDirection.y = jumpSpeed;
            doubleJump = false;
            Debug.Log(doubleJump);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}