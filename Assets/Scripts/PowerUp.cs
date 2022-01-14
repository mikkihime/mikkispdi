using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected Collider2D collider;
    protected Renderer renderer;
    
    protected virtual void Start()
    {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Collect()
    {
        collider.enabled = false;
        renderer.enabled = false;
    }
}
