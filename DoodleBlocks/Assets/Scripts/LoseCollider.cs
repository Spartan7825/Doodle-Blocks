using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession gameSession;

    public void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball checkBall = collision.GetComponent<Ball>();
        if (checkBall != null)
        {

            Ball[] balls = FindObjectsOfType<Ball>();
            if (balls.Length < 2)
            {
                Debug.Log("You Lost");
                Debug.Log(collision.transform.name);
                gameSession.SetCurrentLevelNumber();
                SceneManager.LoadScene("Game Over");
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

    }

}