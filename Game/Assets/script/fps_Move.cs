using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class fps_Move : MonoBehaviour {
    public float sprintSpeed = 20f;
    public float moveSpeed=10f;
    public float jumpSpeed = 4f;
    public float jumpHeight = 20;
    public float gravity = 10f;
    public float rotationSensitivity = 5f;
    public float backSpeed = 3f;
    private CharacterController characterController;
    private fps_playerParamter parameter;
    private Vector3 moveDirection=Vector3.zero;
    private int val=3;

    void Start()
    {
        parameter = GetComponent<fps_playerParamter>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        getMoveVector();
        
        if (characterController.isGrounded)
        {
            if (parameter.inputJump )
            {
                val = 0;
            }
            characterController.Move(moveDirection);
       }
        else
        {
          
            if (val == 0)
            {
                moveDirection.y += jumpSpeed * Time.deltaTime;
            }
            else
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }
            if(transform.localPosition.y > jumpHeight)
            {
                val = 1;
            }
            
            characterController.Move(moveDirection);
        }
        
    }


    private void getMoveVector()
    {
        moveDirection.x = parameter.inputMoveVector.x;
        moveDirection.z = parameter.inputMoveVector.y;
        if (moveDirection.z < 0)
        {
            moveDirection.z /= backSpeed;
        }

        moveDirection = transform.TransformDirection(moveDirection);
            
        if (parameter.inputSprint)
            moveDirection *= sprintSpeed;
        else
            moveDirection *= moveSpeed;
        moveDirection *= Time.deltaTime;




    }
}
