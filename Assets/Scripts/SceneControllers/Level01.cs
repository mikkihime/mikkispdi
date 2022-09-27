using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class Level01 : SceneLoaderScript
    {
        public static bool gameIsPaused = false;

        [field: SerializeField]
        private Button ResumeGameButton { get; set; }
        
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
        
        [field: SerializeField]
        private Button ExitGameButton { get; set; }
        
        [field: SerializeField]
        private PauseUIAnim PauseUIAnim { get; set; }
    
        private void Awake()
        {
            ResumeGameButton.onClick.AddListener(Resume);
            
            QuitGameButton.onClick.AddListener(QuitToMenu);

            ExitGameButton.onClick.AddListener(QuitGame);
        }

        private void Start()
        {
            Cursor.visible = false;
            PauseUIAnim.Setup();
        }
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
        
            if (gameIsPaused)
                Resume();
            else
                Pause();
        }

        private void Resume()
        {
            Time.timeScale = 1f;
            PauseUIAnim.HidePauseAnimation();
            gameIsPaused = false;
            Cursor.visible = false;
        }

        private void Pause()
        {
            PauseUIAnim.ShowPauseAnimation(() => Time.timeScale = 0);
            gameIsPaused = true;
            Cursor.visible = true;
        }

        private void QuitToMenu()
        {
            Time.timeScale = 1f;
            gameIsPaused = false;
            MainMenu();
        }
    }
}
