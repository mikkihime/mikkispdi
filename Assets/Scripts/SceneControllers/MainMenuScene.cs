using SaveAndLoad;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class MainMenuScene : SceneLoaderScript
    {
        
        [field: SerializeField]
        private Button LoadGameButton { get; set; }
        
        [field: SerializeField]
        private Button NewGameButton { get; set; }
        
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
        
        [field: SerializeField]
        private SaveInfo saveInfo { get; set; }

        private void Awake()
        {
            LoadGameButton.onClick.AddListener(() => PlayLevel("Level01"));
            
            NewGameButton.onClick.AddListener(NewGame);

            QuitGameButton.onClick.AddListener(QuitGame);
        }

        private void NewGame()
        {
            saveInfo.ResetData();
            PlayLevel("Level01");
        }

    }
}