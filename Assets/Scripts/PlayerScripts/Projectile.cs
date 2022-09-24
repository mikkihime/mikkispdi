using System;
using System.Collections;
using System.Collections.Generic;
using NPCControllers;
using PlayerScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class Projectile : MonoBehaviour
    {
        protected Rigidbody2D rb;

        [field: SerializeField] protected float projectileSpeed = 10f;

        [field: SerializeField] protected float killTime = 1f;
        
        [field: SerializeField] protected SpriteRenderer FireballSprite { get; set; }

        protected Vector2 direction;

        protected void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        protected void Start()
        {
            StartCoroutine(SelfDestruct());
        }

        protected virtual void FixedUpdate()
        {
            rb.velocity = direction * projectileSpeed;
        }

        public virtual void SetDirection(bool goRight)
        {
            direction = goRight ? Vector2.right : Vector2.left;
            FireballSprite.flipY = !goRight;
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
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
            yield return new WaitForSeconds(killTime);
            Destroy(gameObject);
        }
    }
}