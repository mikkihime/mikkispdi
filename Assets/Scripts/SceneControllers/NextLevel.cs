using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneControllers
{
    public class NextLevel : SceneLoaderScript
    {
        [SerializeField] private string nextLevelSceneName;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayLevel(nextLevelSceneName);
            }
        }
    }
}