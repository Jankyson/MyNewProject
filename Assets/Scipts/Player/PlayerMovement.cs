using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 moveDirection;
    public Animator Animator;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    //remember do physics in here my guy
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        //get axis faw for consistency (only 0 or 1)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        //make player move
        moveDirection = new Vector2(moveX, moveY).normalized; //future me dont forget to come back and fix this later we dont want extra diagonal boosts (future future me dont worry its fixed now)
        //player animations (in if statement to make idle be facing correct direction)
        if (moveDirection != Vector2.zero)
        {
            Animator.SetFloat("moveX", moveX);
            Animator.SetFloat("moveY", moveY);
        }
        Animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }
    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
