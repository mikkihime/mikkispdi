using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collectables
{
    public class Cherries : MonoBehaviour
    {
        protected Collider2D collider;
        protected Renderer renderer;
        public bool collected = false;

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
            gameObject.SetActive(false);
            collected = true;
        }
    }
}