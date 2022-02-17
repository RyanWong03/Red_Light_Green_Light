using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentMovement : MonoBehaviour
{
    CharacterController controller;
    Animator animator;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;
    private float inputVerticalDirection = 0;
    public Text fpsText;
    public float deltaTime;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void HandleMovement(Vector2 input)
    {
        if(controller.isGrounded)
        {
            if(input.y != 0)
            {
                if(input.y > 0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(input.y);
                }
                movementVector = input.y * transform.forward * movementSpeed;
            }
            else
            {
                movementVector = Vector3.zero;
                animator.SetFloat("move", 0); //idle state, doesnt play animation
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y; 

        if(crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private float SetCorrectAnimation(float inputVerticalDirection)
    {
        float currentAnimationSpeed = animator.GetFloat("move");

        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            if(Mathf.Abs(currentAnimationSpeed) < 0.2f)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
                currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, -0.2f, 0.2f);
            }
            animator.SetFloat("move", currentAnimationSpeed);
        }
        else
        {
            if(currentAnimationSpeed < 1)
            {
                currentAnimationSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }

            //Debug.Log(currentAnimationSpeed);
            animator.SetFloat("move", Mathf.Clamp(currentAnimationSpeed, -1, 1));
        }

        if(Input.GetKeyDown("space"))
        {
            animator.SetFloat("move", currentAnimationSpeed);
            Debug.Log("space pressed");
        }
        return Mathf.Abs(currentAnimationSpeed);
    }

    private void Update()
    {
        if(controller.isGrounded)
        {
            if(movementVector.magnitude > 0)
            {
                var animationSpeedMultiplier = SetCorrectAnimation(inputVerticalDirection);
                RotateAgent();
                movementVector *= animationSpeedMultiplier; //decreases movement speed, doesnt move too fast
            }
        }
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
    }
}