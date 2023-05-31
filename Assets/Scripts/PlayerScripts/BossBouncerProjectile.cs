using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class BossBouncerProjectile : Projectile
    {
        protected override void OnCollisionEnter2D(Collision2D other)
        {
           return;
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


