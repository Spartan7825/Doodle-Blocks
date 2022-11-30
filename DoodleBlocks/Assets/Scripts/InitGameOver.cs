using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameOver : MonoBehaviour
{
    GameSession gameSession;
    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.setScore();
        gameSession.isAutoPlayEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
