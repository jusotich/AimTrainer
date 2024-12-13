using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;

    public float lookSpeed = 2f;
    public float lookXLimit = 90f;

    Vector3 moveDiretion = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;

    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //press left shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDiretion.y;
        moveDiretion = (forward * curSpeedX) + (right * curSpeedY);

        if(Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDiretion.y = jumpPower;
        }
        else
        {
            moveDiretion.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDiretion.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDiretion * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0,Input.GetAxis("Mouse X") * lookSpeed,0);
        }
    }
}
