using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class Level01 : SceneLoaderScript
    {
        [field: SerializeField]
        private Button ResumeGameButton { get; set; }
        
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
        
        [field: SerializeField]
        private Button ExitGameButton { get; set; }
    
        private void Awake()
        {
            ResumeGameButton.onClick.AddListener(Resume);
            
            QuitGameButton.onClick.AddListener(QuitToMenu);

            ExitGameButton.onClick.AddListener(QuitGame);
        }

        protected override void Start()
        {
            Cursor.visible = false;
            PauseUIAnimation.Setup();
        }
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }
        

        private void QuitToMenu()
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            MainMenu();
        }
    }
}
