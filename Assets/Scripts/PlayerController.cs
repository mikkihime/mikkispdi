using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private enum State
    {
        Idle,
        Running,
        Jumping,
        Falling,
        Hurt,
    }
    
    private enum Sfx
    {
        Footstep,
        Jump,
        Hurt,
        Kill,
        Coin,
    }
    
    private Rigidbody2D rb;
    private Animator anim;
    private State state = State.Idle;
    private Collider2D collider;
    private SpriteRenderer sprite;
    private Sfx soundEffect;
    private AudioSource playerAudio;
    
    
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
    
    [SerializeField] 
    private float hurtForce = 800f;

    [SerializeField] 
    private AudioClip[] sounds;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        cherriesCount.text = cherries.ToString();
        sprite = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (state != State.Hurt)
        {
            Movement();
        }
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
            SoundFx(Sfx.Coin);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            print("Encostou no inimigo");
            if (state == State.Falling)
            {
                print("matou");
                SoundFx(Sfx.Kill);
                enemy.Die();
                Jump();
            }
            else
            {
                print("vai doer");
                SoundFx(Sfx.Hurt);
                StartCoroutine(HurtCoroutine(other));
            }
        }
    }

    private IEnumerator HurtCoroutine(Collision2D other)
    {
        state = State.Hurt;
        if (other.gameObject.transform.position.x > transform.position.x)
        {
            //enemy is to the right, so  take damage and move left
            rb.velocity = (new Vector2(-hurtForce,hurtForce/2));
        }
        else
        {
            //enemy is to the left, so  take damage and move right
            rb.velocity = (new Vector2(hurtForce,hurtForce/2));
                    
        }

        yield return new WaitForSeconds(.2f);

        while (Mathf.Abs(rb.velocity.magnitude) > 1f)
        {
            sprite.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(.01f);
            sprite.color = new Color(1, 1, 1, 1);
            yield return new WaitForEndOfFrame();

        }

        state = State.Idle;
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
            SoundFx(Sfx.Jump);
            Jump();
        }
        if (rb.velocity.magnitude < 2f)
        {
            rb.velocity= new Vector2(0, rb.velocity.y);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        state = State.Jumping;
        
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
        else if (state == State.Hurt)
        {
            //tá na corrotina
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

    private void SoundFx(Sfx sound)
    {
        switch (sound)
        {
            case Sfx.Footstep:
                playerAudio.clip = sounds[0];
                playerAudio.Play();
                break;
            case Sfx.Jump:
                playerAudio.clip = sounds[1];
                playerAudio.Play();
                break;
            case Sfx.Coin:
                playerAudio.clip = sounds[2];
                playerAudio.Play();
                break;
            case Sfx.Hurt:
                playerAudio.clip = sounds[3];
                playerAudio.Play();
                break;
            case Sfx.Kill:
                playerAudio.clip = sounds[4];
                playerAudio.Play();
                break;
            default:
                return;
        }
    }
}
