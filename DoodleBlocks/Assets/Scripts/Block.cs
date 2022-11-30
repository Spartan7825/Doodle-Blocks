using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] ParticleSystem.MainModule settings;
    SpriteRenderer m_spriteRenderer;
    [SerializeField] Color color;

    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    DissolveEffect dissolveEffect;
    PowerUpDrop powerupDrop;

    private void Start()
    {

        settings = blockSparklesVFX.transform.GetChild(0).GetComponent<ParticleSystem>().main;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        color = m_spriteRenderer.color;

        powerupDrop = FindObjectOfType<PowerUpDrop>();

        dissolveEffect = GetComponent<DissolveEffect>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {

        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball checkBall = collision.gameObject.GetComponent<Ball>();
        if (checkBall != null)
        {
            HandleHit();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball checkBall = collision.GetComponent<Ball>();
        if (checkBall != null)
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {

                DestroyBlock();
            }
            else
            {
                PlayBlockDestroySFX();
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        settings.startColor = (m_spriteRenderer.color);
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }


    }

    private void DestroyBlock()
    {
        powerupDrop.Drop(transform.position);
        Destroy(transform.GetComponent<BoxCollider2D>());
        PlayBlockDestroySFX();

        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();

        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        dissolveEffect.SetIsDissolving();
        StartCoroutine("deleteObject");

        //GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        //Destroy(sparkles, 1f);

    }

    IEnumerator deleteObject()
    {
        yield return new WaitUntil(dissolveEffect.GetDissolveAmount);
        Destroy(gameObject);
    }

}