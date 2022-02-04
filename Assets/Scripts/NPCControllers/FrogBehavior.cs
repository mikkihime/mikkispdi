using UnityEngine;

namespace NPCControllers
{
  public class FrogBehavior : Enemy
  {
    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;

  
    [SerializeField] private LayerMask ground;
  
    private bool facingLeft = true;

    private void Update()
    {
      if (anim.GetBool("Jumping"))
      {
        if (rb.velocity.y < .1f)
        {
          anim.SetBool("Jumping" , false);
          anim.SetBool("Falling", true);
        }
      }

      if (collider.IsTouchingLayers(ground) && anim.GetBool("Falling"))
      {
        anim.SetBool("Falling", false);
      }
    }

    private void Move()
    {
      if (facingLeft)
      {
        //check if it's beyond the leftCap
        if (transform.position.x > leftCap)
        {
          //make sure the sprite is pointing to the correct direction
          if (transform.localScale.x != 1)
          {
            transform.localScale = new Vector3(1, 1);
          }

          if (collider.IsTouchingLayers(ground))
          {
            rb.velocity = new Vector2(-jumpLength, jumpHeight);
            anim.SetBool("Jumping" , true);

          }
        }
        else
        {
          facingLeft = false;
        }
      }
      else
      {
        if (transform.position.x < rightCap)
        {
          if (transform.localScale.x != -1)
          {
            transform.localScale = new Vector3(-1, 1);
          }

          if (collider.IsTouchingLayers(ground))
          {
            rb.velocity = new Vector2(jumpLength, jumpHeight);
            anim.SetBool("Jumping" , true);

          }
        }
        else
        {
          facingLeft = true;
        }
      }
    }

  
  }
}
