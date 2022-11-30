using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public int speed = 1;
    public int powerUpIndex;

    public Paddle paddle;
    public PowerUpDrop powerUpDrop;


    public void Start()
    {
        paddle = FindObjectOfType<Paddle>();
        powerUpDrop = FindObjectOfType<PowerUpDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2)
        {
            powerUpDrop.ReSpawnPowerUp();
            Destroy(gameObject);

        }
        transform.Translate(0, -speed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        powerUpDrop.StartPowerUp(collision, paddle, gameObject);



        // Debug.Log(collision.name);
    }


}