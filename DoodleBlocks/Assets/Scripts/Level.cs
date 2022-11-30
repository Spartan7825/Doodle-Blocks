using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            
            gameSession.SetCurrentLevelNumber();
            
            PlayerPrefs.SetInt("level"+ (gameSession.GetCurrentLevelNumber() - 2).ToString(), 1);
            sceneLoader.LoadLevelCompletion();
        

        }
    
    
    }


}
