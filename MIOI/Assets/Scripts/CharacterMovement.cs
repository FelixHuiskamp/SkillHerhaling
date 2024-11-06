using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float normalSpeed = 2.0f;
    public float sprintSpeed = 6.0f;
    public float acceleration = 1.0f;
    public float deceleration = 0.05f;

    private float currentSpeed; 
    private Animator animator;

    void Start()
    {
        currentSpeed = normalSpeed;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        bool isSprinting = Input.GetKey(KeyCode.Space);

        if (isSprinting)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, deceleration * Time.deltaTime);
        }

        if (currentSpeed < 0.1f) 
        {
            currentSpeed = 0f;
        }


        if (currentSpeed > 0f) 
        { 
            transform.Translate(Vector3.forward * currentSpeed *  Time.deltaTime);
        } 

        Debug.Log(currentSpeed);
        

        if (animator != null) 
        { 
            animator.SetFloat("Speed", currentSpeed);
        }
    }

}
