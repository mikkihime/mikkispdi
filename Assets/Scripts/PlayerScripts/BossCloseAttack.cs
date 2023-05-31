using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts
{
    public class BossCloseAttack : Projectile
    {
        public override void SetDirection(bool goRight)
        {
            direction = Vector2.down;
            FireballSprite.flipY = !goRight;
        }
    }
}


