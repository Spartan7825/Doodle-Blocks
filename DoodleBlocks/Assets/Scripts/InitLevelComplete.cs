using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InitLevelComplete : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] TextMeshProUGUI score;
    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        score.text = gameSession.currentScore.ToString();
        AdManager.instance.RequestInterstitial();
        AdManager.instance.ShowInterstitial();
        gameSession.isAutoPlayEnabled = false;
    }

}
