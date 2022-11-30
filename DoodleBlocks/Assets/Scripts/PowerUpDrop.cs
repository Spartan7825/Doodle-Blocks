using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDrop : MonoBehaviour
{
    public List<Sprite> icons;
    public GameObject AbilityPlaceHolder;
    public bool isPowerupActive = false;
    public bool spawnPowerUp = true;
    IEnumerator power1Coroutine;
    int powerupIndex;
    public GameObject[] blocks;
    Ball ball;
    public GameObject ballPrefab;
    public float powerup1Duration;
    public float powerup2Duration;
    public bool isMultipleBalls;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMultipleBalls)
        {
            Ball[] balls = FindObjectsOfType<Ball>();
            if (balls.Length < 2)
            {
                isPowerupActive = false;
                isMultipleBalls = false;
                ReSpawnPowerUp();
            }
        }



    }

    public void Drop(Vector3 position)
    {
        if (spawnPowerUp && !isPowerupActive)
        {
            powerupIndex = Random.Range(0, 3);
            spawnPowerUp = false;
            if (Random.Range(0, 10) <= 7)
            {
                GameObject powerup = Instantiate(AbilityPlaceHolder, position, Quaternion.identity);
                powerup.GetComponent<SpriteRenderer>().sprite = icons[powerupIndex];
                powerup.GetComponent<PowerUpMovement>().powerUpIndex = powerupIndex;
            }
        }


    }

    public void StartPowerUp(Collider2D collision, Paddle paddle, GameObject powerUpPlaceHolder)
    {
        if (collision.GetComponent<Paddle>() != null)
        {
            Destroy(powerUpPlaceHolder);
            if (powerupIndex == 0)
            {
                isPowerupActive = true;
                paddle.transform.localScale = paddle.transform.localScale * 2;
                power1Coroutine = StartPowerUp1(paddle, powerup1Duration);
                StartCoroutine(power1Coroutine);

            }
            else if (powerupIndex == 1)
            {
                isPowerupActive = true;
                blocks = GameObject.FindGameObjectsWithTag("Breakable");
                ball = FindObjectOfType<Ball>();
                ball.transform.GetChild(0).transform.gameObject.SetActive(true);
                foreach (var block in blocks)
                {
                    if (block != null)
                    {
                        block.GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                }
                StartCoroutine(StartPowerUp2());

            }
            else if (powerupIndex == 2)
            {
                isPowerupActive = true;
                isMultipleBalls = true;
                ball = FindObjectOfType<Ball>();
                GameObject newBall = Instantiate(ballPrefab, ball.transform.position, ball.transform.rotation);
                newBall.GetComponent<Ball>().LaunchPowerUpBall();
                GameObject newBall1 = Instantiate(ballPrefab, ball.transform.position, ball.transform.rotation);
                newBall1.GetComponent<Ball>().LaunchPowerUpBall();

            }




        }


    }

    public IEnumerator StartPowerUp1(Paddle paddle, float powerup1Duration)
    {

        yield return new WaitForSeconds(powerup1Duration);

        paddle.transform.localScale = paddle.transform.localScale / 2;


        isPowerupActive = false;
        ReSpawnPowerUp();

    }
    public IEnumerator StartPowerUp2()
    {

        yield return new WaitForSeconds(powerup2Duration);


        isPowerupActive = false;
        blocks = GameObject.FindGameObjectsWithTag("Breakable");
        ball = FindObjectOfType<Ball>();
        ball.transform.GetChild(0).transform.gameObject.SetActive(false);
        foreach (var block in blocks)
        {
            if (block != null)
            {
                block.GetComponent<BoxCollider2D>().isTrigger = false;
            }

        }

        isPowerupActive = false;
        ReSpawnPowerUp();

    }

    public void ReSpawnPowerUp()
    {
        spawnPowerUp = true;

    }
}
