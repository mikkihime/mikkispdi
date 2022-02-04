using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class Level02 : SceneLoaderScript
    {
        [field: SerializeField]
        private Button MainMenuButton { get; set; }
    
        [field: SerializeField]
        private Button QuitGameButton { get; set; }

        private void Awake()
        {
            MainMenuButton.onClick.AddListener(MainMenu);
            QuitGameButton.onClick.AddListener(QuitGame);
        }
    }
}

