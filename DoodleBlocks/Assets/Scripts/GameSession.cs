using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] public int currentScore = 0;
    [SerializeField] public bool isAutoPlayEnabled;
    int currentLevel;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore;

    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void Start()
    {
        scoreText.text = currentScore.ToString();



    }


    private void Update()
    {
        //Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {

        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void SetCurrentLevelNumber()
    { 
    currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public int GetCurrentLevelNumber()
    {
        return currentLevel;
    }

    public void setScore()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        score.text = currentScore.ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore.text = currentScore.ToString();
        }

    }


}
