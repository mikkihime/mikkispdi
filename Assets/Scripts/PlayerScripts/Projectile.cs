using System;
using System.Collections;
using System.Collections.Generic;
using NPCControllers;
using PlayerScripts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;

    [field: SerializeField] private float projectileSpeed = 10f;

    private Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * projectileSpeed;
    }

    public void SetDirection(bool goRight)
    {
        direction = goRight ? Vector2.right : Vector2.left;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Die();
        }
        
        Destroy(gameObject);
    }
    
    IEnumerator SelfDestruct()
    {
        if (gameObject == null) 
            yield break;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
