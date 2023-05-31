using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using SceneControllers;
using Unity.Mathematics;
using UnityEngine;

namespace NPCControllers
{
    public class BossBehavior : MonoBehaviour
    {
        private enum State
        {
            Idle,
            CloseAttack,
            FarAttack,
            Hurt
        }
        
        [field: SerializeField]
        private Transform PlayerTransform { get; set; }
        
        [field: SerializeField]
        private Transform AttackTransform { get; set; }
        
        [field: SerializeField]
        private Transform RightLimiter { get; set; }
        
        [field: SerializeField]
        private Transform LeftLimiter { get; set; }
        
        [field: SerializeField]
        private Projectile longDistanceProjectile;
        
        [field: SerializeField]
        private Projectile closeAttackProjectile;

        [field: SerializeField]
        private Transform transform;
        private Rigidbody2D rb;
        private Animator anim;
        private State state = State.Idle;
        private Collider2D collider;
        public SpriteRenderer sprite;
        
        public bool facingRight;
        public float bossScale = 1f;
        private bool cooldown;
        [SerializeField] 
        public float runningSpeed = 3f;
        [SerializeField] 
        private float closeAttackDistance = 20;

        private bool hitLeftWall = false;
        private bool hitRightWall = false;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            collider = GetComponent<Collider2D>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var position = transform.position;
            var playerDistance = Vector3.Distance(PlayerTransform.position, position);
            if (Math.Abs(position.x - LeftLimiter.position.x) < 5)
                facingRight = true;
            if (Math.Abs(position.x - RightLimiter.position.x) < 5)
                facingRight = false;
            
            if (playerDistance > closeAttackDistance)
            {
                if (!facingRight)
                {
                    rb.velocity = new Vector2(-runningSpeed, rb.velocity.y );
                    transform.localScale = new Vector2(bossScale, bossScale);
                }
                else
                {
                    rb.velocity = new Vector2(runningSpeed, rb.velocity.y);
                    transform.localScale = new Vector2(-bossScale, bossScale);
                }

                if (!cooldown && !Level02.gameIsPaused)
                {
                    LongDistance();
                    StartCoroutine(AttackingCooldown());
                }
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                if (!cooldown && !Level02.gameIsPaused)
                {
                    ShortDistance();
                    StartCoroutine(AttackingCooldown());
                }
            }
        }

        void LongDistance()
        {
            Vector2 shooterPosition = new Vector2(AttackTransform.position.x, AttackTransform.position.y);
            Instantiate(longDistanceProjectile, shooterPosition,
                quaternion.identity).SetDirection(facingRight);
        }
        
        void ShortDistance()
        {
            Vector2 shooterPosition = new Vector2(AttackTransform.position.x, AttackTransform.position.y);
            Instantiate(closeAttackProjectile, shooterPosition,
                quaternion.identity).SetDirection(facingRight);
        }
        IEnumerator AttackingCooldown()
        {
            cooldown = true;
            yield return new WaitForSeconds(1f);
            cooldown = false;

        }
    }
}
