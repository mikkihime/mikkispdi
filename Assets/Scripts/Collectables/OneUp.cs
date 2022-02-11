using System.Collections;
using System.Collections.Generic;
using Collectables;
using PlayerScripts;
using UnityEngine;

namespace Collectables
{
    public class OneUp : PowerUp
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.HandleHealth(true);
                Collect();

            }
        }
    }

}
