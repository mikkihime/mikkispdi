using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float leftCap;
    [SerializeField] protected float rightCap;

    protected Animator anim;
    protected Rigidbody2D rb;
    protected Collider2D collider;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        collider.enabled = false;
        rb.gravityScale = 0;
        anim.SetTrigger("Death");
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
