using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum State
    {
        Idle,
        Running,
        Jumping,
        Falling,
    }
    
    private Rigidbody2D rb;
    private Animator anim;
    private State state = State.Idle;
    private Collider2D collider;
    [SerializeField] 
    private LayerMask groundLayer;

    [SerializeField] 
    private float runningSpeed = 5f;

    [SerializeField] 
    private float jumpHeight = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Movement();
        AnimationStates();
        anim.SetInteger("state", (int)state);
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
       
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-runningSpeed, rb.velocity.y );
            transform.localScale = new Vector2(-1, 1);
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            anim.SetBool("running", false);
        }
        if (Input.GetButtonDown("Jump") && collider.IsTouchingLayers(groundLayer))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            state = State.Jumping;
        }
    }

    private void AnimationStates()
    {
        if (state == State.Jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.Falling;
            }
        }
        else if (state == State.Falling)
        {
            if (collider.IsTouchingLayers(groundLayer))
            {
                state = State.Idle; 
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.Running;
        }
        else
        {
            state = State.Idle;
        }
        
    }
}
