using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class YouDiedScene : MonoBehaviour
    {

        [field: SerializeField]
        private Button MainMenuButton { get; set; }
    
        [field: SerializeField]
        private Button RestartLevelButton { get; set; }
    
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
    }
}

