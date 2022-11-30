using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    Ball theBall;
    public GameObject leftButton;
    public GameObject rightButton;
    pauseBtnScript pbs;
    GameSession theGameSession;

    private void Start()
    {
        pbs = FindObjectOfType<pauseBtnScript>();
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    void Update()
    {
       
       
       // Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        Vector2 paddlePos = transform.position;
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
        
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            //return theBall.transform.position.x;
            GameObject[] blocks = GameObject.FindGameObjectsWithTag("Breakable");
            List<GameObject> rightBlocks = new List<GameObject>();
            List<GameObject> leftBlocks = new List<GameObject>();
            foreach (var block in blocks)
            {
                if (block.transform.position.x > transform.position.x)
                {
                    rightBlocks.Add(block);
                }
                else
                {
                    leftBlocks.Add(block);
                }
            }
            if (rightBlocks.Count > leftBlocks.Count)
            {
                return theBall.transform.position.x - 1;
            }
            else if (leftBlocks.Count > rightBlocks.Count)
            {
                return theBall.transform.position.x + 1;
            }
            else
            {
                return theBall.transform.position.x;
            }
        }
        else
        {
            if (!pbs.isPaused)
            {
                if (leftButton.GetComponent<MyButton>().buttonPressed)
                {
                    return transform.position.x - 0.3f + Time.deltaTime;
                }
                else if (rightButton.GetComponent<MyButton>().buttonPressed)
                {
                    return transform.position.x + 0.3f + Time.deltaTime;
                }
                else
                {
                    return transform.position.x;
                }
            }

            else
            {
                return transform.position.x;
            }
        
        }
    
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle = (offset / maxOffset) * 75;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -75, 75);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}
