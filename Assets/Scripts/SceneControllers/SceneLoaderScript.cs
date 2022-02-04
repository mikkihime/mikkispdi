using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
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

    protected void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
