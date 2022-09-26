using System.Collections;
using PlayerScripts;
using UnityEngine;

namespace Collectables
{
    public class GemPowerUp : PowerUp
    {

        [SerializeField] private float duration = 5f;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                StartCoroutine(GemDuration(player));

            }
        }

        private IEnumerator GemDuration(PlayerController player)
        {
            player.invincible = true;
            player.invincibleGem = true;
            Collect();
            player.playerScale *= 1.5f;
            player.runningSpeed = 14f;
            yield return new WaitForSeconds(duration);
            player.playerScale /= 1.5f;
            player.runningSpeed = 7f;
            player.invincible = false;
            player.invincibleGem = false;
            player.KillRainbow();
            Destroy(gameObject);
        }
    }
}
