using UnityEngine;

namespace PlayerScripts
{
   public class Falling : MonoBehaviour
   {
      [SerializeField] private PlayerController player;
      private void OnTriggerEnter2D(Collider2D collision)
      {
         if (collision.gameObject.tag == "Player")
         {
         
            player.SoundFx(PlayerController.Sfx.Hurt);
            player.HandleFall();
         }
      }
   }
}
