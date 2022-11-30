using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    public AudioSource myAudioSource;

    bool hasStarted = false;

    Vector2 paddleToBallVector;

    [SerializeField] float randomFactor = 0.5f;
    public Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddle1 = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Mathf.Clamp(myRigidBody2D.velocity.x, -11, 11);
        var y = Mathf.Clamp(myRigidBody2D.velocity.y, -12, 12);
        //var xMax = 10/x;
        //var yMax = 10/y;
        // x = x * xMax;
        // y = y * yMax;
        myRigidBody2D.velocity = new Vector2(x, y);

        //Debug.Log(myRigidBody2D.velocity);
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();

        }



    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            myRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
        }

    }

    public void LaunchPowerUpBall()
    {
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
        hasStarted = true;
        myRigidBody2D.velocity = new Vector2(xPush + Random.Range(-10, 10), yPush);

    }


    private void LockBallToPaddle()
    {
        myRigidBody2D.bodyType = RigidbodyType2D.Kinematic;
        // Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        Vector2 paddlePos = paddle1.transform.position;
        transform.position = paddlePos + paddleToBallVector;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0, randomFactor));
        if (hasStarted)
        {
            if (collision.transform.tag != "Breakable")
            {
                AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
                myAudioSource.PlayOneShot(clip);
            }


            //  myRigidBody2D.AddForce(velocityTweak);

        }
    }

}