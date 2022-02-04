using UnityEngine;

namespace NPCControllers
{
  public class EagleBehavior : Enemy
  {
   
    private bool facingLeft = true;

    [SerializeField] private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
      Move();
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
          rb.velocity = new Vector2(-speed,  rb.velocity.y); 
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
          rb.velocity = new Vector2(speed, rb.velocity.y);

        }
        else
        {
          facingLeft = true;
        }
      }
    }
  }
}
