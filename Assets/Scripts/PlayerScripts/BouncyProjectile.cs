using System.Collections;
using System.Collections.Generic;
using NPCControllers;
using UnityEngine;

namespace PlayerScripts
{
    public class BouncyProjectile : Projectile
    {
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != "Enemy") return;
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.Die();
            Destroy(gameObject);

        }
        public override void SetDirection(bool goRight)
        {
            rb.AddForce((goRight? Vector2.right : Vector2.left) * projectileSpeed);
        }
        
        protected override void FixedUpdate()
        {
          //  rb.velocity = new Vector2(direction.x * projectileSpeed, rb.velocity.y);
          return;
        }
    }
}
