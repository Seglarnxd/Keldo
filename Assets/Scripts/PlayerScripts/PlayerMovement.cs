using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    private Rigidbody2D rb;
    private bool _facingRight = true;
    private float moveDirection;
   [SerializeField] private bool isJumping = false;
   [SerializeField] private bool isGrounded;
    private int jumpCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpCount = maxJumpCount;
    }

    void Update()
    {
        ProcessInputs();
        if (Input.GetButtonDown("Jump") && !isJumping && isGrounded)
        {
            isJumping = true;
        }
        else if (Input.GetButton("Jump") && !isJumping && isGrounded)
        {
            isJumping = true;
        }

        Animate();

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        if (isGrounded)
        {
            jumpCount = maxJumpCount;
        }
        
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping && jumpCount > 0 && rb.velocity.y < 0.5f)
        {
            rb.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animate()
    {
        if (moveDirection > 0 && !_facingRight)
        {
            FlipSprite();
        }
        else if (moveDirection < 0 && _facingRight)
        {
            FlipSprite();
        }
    }

    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            isJumping = true;
        }
    }

    private void FlipSprite()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == 3) // 3 = ground
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.layer == 3) // 3 = ground
        {
            isGrounded = false;
        }
    }
}
