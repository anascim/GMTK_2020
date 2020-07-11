﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public float velocity = 1f;
    public float jumpForce = 2f;
    public bool canWalk = true;
    public bool canJump = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (canWalk)
        {
            float hMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(hMove * velocity, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
