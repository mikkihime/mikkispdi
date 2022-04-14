using UnityEngine;

namespace Collectables
{
    public class PowerUp : MonoBehaviour
    {
        protected Collider2D collider;
        protected Renderer renderer;
        protected bool collected = false;
    
        protected virtual void Start()
        {
            if (collected)
            {
                gameObject.SetActive(false);
                return;
            }
            collider = GetComponent<Collider2D>();
            renderer = GetComponent<SpriteRenderer>();
        }

        public void Collect()
        {
            collider.enabled = false;
            renderer.enabled = false;
            collected = true;
        }
    }
}
