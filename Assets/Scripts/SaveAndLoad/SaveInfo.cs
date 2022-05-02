using System;
using System.Collections.Generic;
using Collectables;
using NPCControllers;
using PlayerScripts;
using UnityEngine;

namespace SaveAndLoad
{
    public class SaveInfo : MonoBehaviour
    {
        [field: SerializeField] private Cherries[] cherries;

        [field: SerializeField] private GemPowerUp[] gems;

        [field: SerializeField] private Checkpoint[] checkpoints;

        [field: SerializeField] private Enemy[] enemies;

        private int[] collectedCherries;
        private int[] collectedGems;
        private int[] activatedCheckpoints;
        private int[] defeatedEnemies;

        private int lastCheckpointNumber;

        private int playerLives;

        private int playerCherries;

        private Vector2 playerCheckpoint;

        [field: SerializeField] private PlayerController player;

        public void Awake()
        {
            collectedCherries = new int[cherries.Length];
            collectedGems = new int[gems.Length];
            activatedCheckpoints = new int[checkpoints.Length];
            defeatedEnemies = new int[enemies.Length];

            LoadGame();
        }

        public void SaveGame(PlayerController playerData)
        {
            SavePlayerData(playerData);
            SaveLevelData();
            PlayerPrefs.Save();
            Debug.Log("Game data saved!");
        }

        public bool LoadGame()
        {
            if (PlayerPrefs.HasKey("PlayerLives"))
            {
                LoadLevelData();
                LoadPlayerData();
                LoadLastCheckpoint();
                
                Debug.Log("Game data loaded!");
                return true;
            }
            else
            {
                Debug.LogError("There is no save data!");

                return false;
            }
        }

        public void LoadPlayerData()
        {
            playerLives = PlayerPrefs.GetInt("PlayerLives");
            playerCherries = PlayerPrefs.GetInt("PlayerCherries");
            playerCheckpoint.x = PlayerPrefs.GetFloat("CheckpointX");
            playerCheckpoint.y = PlayerPrefs.GetFloat("CheckpointY");

            player.lives = playerLives;
            player.cherries = playerCherries;
            player.initSpawn = playerCheckpoint;
        }

        private void LoadLevelData()
        {
            for (int cherryn = 0; cherryn < cherries.Length; cherryn++)
            {
                int cherry = PlayerPrefs.GetInt("CollectedCherries" + cherryn);
                cherries[cherryn].collected = cherry != 0;
            }

            for (int gemn = 0; gemn < gems.Length; gemn++)
            {
                int gem = PlayerPrefs.GetInt("CollectedGems" + gemn);
                gems[gemn].collected = gem != 0;
            }

            for (int checkpointn = 0; checkpointn < checkpoints.Length; checkpointn++)
            {
                int checkpoint = PlayerPrefs.GetInt("ActivatedCheckpoints" + checkpointn);
                checkpoints[checkpointn].passed = checkpoint != 0;
            }

            for (int enemyn = 0; enemyn < enemies.Length; enemyn++)
            {
                int enemy = PlayerPrefs.GetInt("DefeatedEnemies" + enemyn);
                enemies[enemyn].defeated = enemy != 0;
            }
        }

        private void LoadLastCheckpoint()
        {
            for (int n = 0; n < checkpoints.Length; n++)
            {
                if (PlayerPrefs.GetInt("ActivatedCheckpoints" + n) == 0)
                    break;

                lastCheckpointNumber = n;
            }

            float checkpointx = checkpoints[lastCheckpointNumber].gameObject.transform.position.x;
            float checkpointy = checkpoints[lastCheckpointNumber].gameObject.transform.position.y;
            Vector2 playerSpawn = new Vector2(checkpointx, checkpointy);
            player.initSpawn = playerSpawn;

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

        private void SaveLevelData()
        {
            for (int cherryn = 0; cherryn < cherries.Length; cherryn++)
            {
                var cherry = cherries[cherryn];
                collectedCherries[cherryn] = cherry.collected ? 1 : 0;
                PlayerPrefs.SetInt("CollectedCherries" + cherryn, collectedCherries[cherryn]);
            }

            PlayerPrefs.SetInt("CherriesCount", collectedCherries.Length);

            for (int gemn = 0; gemn < gems.Length; gemn++)
            {
                var gem = gems[gemn];
                collectedGems[gemn] = gem.collected ? 1 : 0;
                PlayerPrefs.SetInt("CollectedGems" + gemn, collectedGems[gemn]);
            }

            PlayerPrefs.SetInt("GemsCount", collectedGems.Length);

            for (int checkpointn = 0; checkpointn < checkpoints.Length; checkpointn++)
            {
                var checkpoint = checkpoints[checkpointn];
                activatedCheckpoints[checkpointn] = checkpoint.passed ? 1 : 0;
                PlayerPrefs.SetInt("ActivatedCheckpoints" + checkpointn, activatedCheckpoints[checkpointn]);
            }

            PlayerPrefs.SetInt("CheckpointsCount", activatedCheckpoints.Length);

            for (int enemyn = 0; enemyn < enemies.Length; enemyn++)
            {
                var enemy = enemies[enemyn];
                defeatedEnemies[enemyn] = enemy.defeated ? 1 : 0;
                PlayerPrefs.SetInt("DefeatedEnemies" + enemyn, defeatedEnemies[enemyn]);
            }

            PlayerPrefs.SetInt("EnemiesCount", defeatedEnemies.Length);
            
            PlayerPrefs.Save();
        }
    }
}