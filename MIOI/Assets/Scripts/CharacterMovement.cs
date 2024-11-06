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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, normalSpeed, deceleration * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (animator != null) 
        { 
            animator.SetFloat("Speed", currentSpeed);
        }
    }

}
