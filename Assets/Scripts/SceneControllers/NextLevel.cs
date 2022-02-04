using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneControllers
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private string nextLevelSceneName;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(nextLevelSceneName);
            }
        }
    }
}