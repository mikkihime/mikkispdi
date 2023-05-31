using System.Collections;
using System.Collections.Generic;
using SceneControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    
    [field: SerializeField] protected PauseUIAnim PauseUIAnimation { get; set; }
    
    protected virtual void Start()
    {
        PauseUIAnimation.Setup();
    }
    
    protected void Resume()
    {
        Time.timeScale = 1f;
        PauseUIAnimation.HidePauseAnimation();
        gameIsPaused = false;
        Cursor.visible = false;
    }

    protected void Pause()
    {
        PauseUIAnimation.ShowPauseAnimation(() => Time.timeScale = 0);
        gameIsPaused = true;
        Cursor.visible = true;
    }
    
    protected void PlayLevel(string level)
    {
        Debug.Log("Level");

        SceneManager.LoadScene(level);
    }
    

    protected void MainMenu()
    {
        Debug.Log("Main");

        SceneManager.LoadScene("MainMenu");
    }
    
    protected void Shop()
    {
        Debug.Log("Main");

        SceneManager.LoadScene("Shop");
    }

    protected void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
