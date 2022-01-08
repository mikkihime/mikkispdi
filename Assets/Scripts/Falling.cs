using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
