using System;
using PlayerScripts;
using UnityEngine;

namespace SaveAndLoad
{
   public class SaveInfo : MonoBehaviour
   {
      private int playerLives;
   
      private int playerCherries;
   
      private Vector2 playerCheckpoint;
   
      [field: SerializeField] private PlayerController player;

    public void SaveGame(int lives, int cherries, float x, float y)
      {
         playerLives = lives;
         playerCherries = cherries;
         playerCheckpoint.x = x;
         playerCheckpoint.y = y;
         
         PlayerPrefs.SetInt("PlayerLives", playerLives);
         PlayerPrefs.SetInt("PlayerCherries", playerCherries);
         PlayerPrefs.SetFloat("CheckpointX", x);
         PlayerPrefs.SetFloat("CheckpointY", y);
         
         PlayerPrefs.Save();
         Debug.Log("Game data saved!");
      }
      
      public bool LoadGame()
      {
         if (PlayerPrefs.HasKey("PlayerLives"))
         {
            playerLives = PlayerPrefs.GetInt("PlayerLives");
            playerCherries = PlayerPrefs.GetInt("PlayerCherries");
            playerCheckpoint.x = PlayerPrefs.GetFloat("CheckpointX");
            playerCheckpoint.y = PlayerPrefs.GetFloat("CheckpointY");
            
            Debug.Log("Game data loaded!");
   
            player.lives = playerLives;
            player.cherries = playerCherries;
            player.initSpawn = playerCheckpoint;

            return true;
         }
         else
         {
            Debug.LogError("There is no save data!");

            return false;
         }
      }
      
      public void ResetData()
      {
         PlayerPrefs.DeleteAll();
         
         Debug.Log("Data reset complete");
      }
   }
}
