using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using SaveAndLoad;
using UnityEngine;


namespace Collectables
{
    public class Checkpoint : MonoBehaviour
    {
        private Collider2D collider;

        [field: SerializeField] private SaveInfo saveInfo;

        void Start()
        {
            collider = GetComponent<Collider2D>();

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.initSpawn = collider.transform.position + Vector3.up*4;
                collider.enabled = false;
                saveInfo.SaveGame(player.lives, player.cherries, player.initSpawn.x, player.initSpawn.y);
            }
        }
    }
}

