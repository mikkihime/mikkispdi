using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Level01 : SceneLoaderScript
{
    [field: SerializeField]
    private GameObject PauseMenuUI { get; set; }
    
    public static bool gameIsPaused = false;

    [field: SerializeField]
    private Button ResumeGameButton { get; set; }
        
    [field: SerializeField]
    private Button QuitGameButton { get; set; }
        
    [field: SerializeField]
    private Button ExitGameButton { get; set; }
    
    private void Awake()
    {
        ResumeGameButton.onClick.AddListener(Resume);
            
        QuitGameButton.onClick.AddListener(MainMenu);

        ExitGameButton.onClick.AddListener(QuitGame);
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
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
