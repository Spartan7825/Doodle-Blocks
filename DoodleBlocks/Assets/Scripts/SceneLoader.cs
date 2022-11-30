using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameSession gameSession;
    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (gameSession.GetCurrentLevelNumber() < 13)
        {
            SceneManager.LoadScene(gameSession.GetCurrentLevelNumber() + 1);
        }
        
    }



    public void LoadThisScene()
    {
        gameSession.ResetGame();

        SceneManager.LoadScene(gameSession.GetCurrentLevelNumber());
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadLevelCompletion()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
