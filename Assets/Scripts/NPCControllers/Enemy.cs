using UnityEngine;

namespace NPCControllers
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected float leftCap;
        [SerializeField] protected float rightCap;

        protected Animator anim;
        protected Rigidbody2D rb;
        protected Collider2D collider;
        protected bool defeated = false;

        protected virtual void Start()
        {
            if (defeated)
            {
                gameObject.SetActive(false);
                return;
            }
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
            defeated = true;
            anim.SetTrigger("Death");
        }

        public void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }
}
