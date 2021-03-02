using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedUp;
    public bool right = true;
    private float runSpeed = 1.3F;
    private float speed = 6F;
    private float gravity = 20.0F;
    private float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public GameObject playerAssets;

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
            moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * runSpeed * speedUp;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        else if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * speedUp;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}