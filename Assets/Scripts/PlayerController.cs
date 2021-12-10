using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

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
    public int cherries = 0;

    [SerializeField] 
    private Text cherriesCount;
    
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
        cherriesCount.text = cherries.ToString();

    }

    private void Update()
    {
        Movement();
        AnimationStates();
        anim.SetInteger("state", (int)state);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cherry")
        {  
            Destroy(collision.gameObject);
            cherries += 1;
            cherriesCount.text = cherries.ToString();
        }
        
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection.Equals(0f))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
       
        else if (hDirection < 0)
        {
            rb.velocity = new Vector2(-runningSpeed, rb.velocity.y );
            transform.localScale = new Vector2(-1, 1);
        }
        else 
        {
            rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        
      
        if (Input.GetButtonDown("Jump") && collider.IsTouchingLayers(groundLayer))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            state = State.Jumping;
        }
        
        print(rb.velocity.magnitude);

        if (rb.velocity.magnitude < 2f)
        {
            rb.velocity = Vector2.zero;
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
        else if (!Mathf.Approximately(Mathf.Abs(rb.velocity.x),0f))
        {
            state = State.Running;
        }
        else
        {
            state = State.Idle;
        }
        
    }
}
