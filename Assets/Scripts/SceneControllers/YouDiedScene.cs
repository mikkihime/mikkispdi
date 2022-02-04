using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SceneControllers
{
    public class YouDiedScene : SceneLoaderScript
    {

        [field: SerializeField]
        private Button MainMenuButton { get; set; }
    
        [field: SerializeField]
        private Button RestartLevelButton { get; set; }
    
        [field: SerializeField]
        private Button QuitGameButton { get; set; }

        private void Awake()
        {
            MainMenuButton.onClick.AddListener(MainMenu);
            RestartLevelButton.onClick.AddListener(() => PlayLevel("Level01"));
            QuitGameButton.onClick.AddListener(QuitGame);
        }

        
    }
}

