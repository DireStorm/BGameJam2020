﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables & References
    public float mSpeed = 5f;
    private float moveInput;
    Rigidbody2D rb;
    public Animator animator;

    // Jumping
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;


    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * mSpeed, rb.velocity.y);

    }
    //Update is called once per frame
    void Update()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += move * Time.deltaTime * mSpeed;
        animator.SetFloat("Horizontal", moveInput);
        animator.SetBool("isJumping", isJumping);
        Jump();
    }

    void Jump()
    {
        //rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        } else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
