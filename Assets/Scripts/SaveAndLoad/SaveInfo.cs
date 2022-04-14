using System;
using PlayerScripts;
using UnityEngine;

namespace SaveAndLoad
{
   public class SaveInfo : MonoBehaviour
   {
      [field: SerializeField] private GameObject[] cherries;
      
      [field: SerializeField] private GameObject[] gems;

      [field: SerializeField] private GameObject[] checkpoints;
      
      [field: SerializeField] private GameObject[] enemies;

      
      private int playerLives;
   
      private int playerCherries;
   
      private Vector2 playerCheckpoint;
   
      [field: SerializeField] private PlayerController player;

    public void SaveGame(PlayerController playerData)
      {
         SavePlayerData(playerData);
         
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
            
            Debug.Log($" !Mikki é muito esperta");
            
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

      private void SavePlayerData(PlayerController playerData)
      {
         playerLives = playerData.lives;
         playerCherries = playerData.cherries;
         playerCheckpoint = playerData.transform.position;
         
         PlayerPrefs.SetInt("PlayerLives", playerLives);
         PlayerPrefs.SetInt("PlayerCherries", playerCherries);
         PlayerPrefs.SetFloat("CheckpointX", playerCheckpoint.x);
         PlayerPrefs.SetFloat("CheckpointY", playerCheckpoint.y);
         
      }
   }
}
