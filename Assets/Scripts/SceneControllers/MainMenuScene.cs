using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class MainMenuScene : SceneLoaderScript
    {
        
        [field: SerializeField]
        private Button StartGameButton { get; set; }
        
        [field: SerializeField]
        private Button QuitGameButton { get; set; }

        private void Awake()
        {
            StartGameButton.onClick.AddListener(() => PlayLevel("Level01"));

            QuitGameButton.onClick.AddListener(QuitGame);
        }

    }
}