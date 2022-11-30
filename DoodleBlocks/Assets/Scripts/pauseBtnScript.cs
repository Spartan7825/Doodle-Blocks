using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseBtnScript : MonoBehaviour
{
    public bool isPaused;
    public Sprite pauseBtn;
    public Sprite playBtn;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else 
        {
            Time.timeScale = 1;
        }
        
    }
    public void PauseResumeGame() 
    {
        if (isPaused)
        {
            img.sprite = pauseBtn;
            isPaused = false;
        }
        else 
        {
            img.sprite = playBtn;
            isPaused = true;
        }
    }

    public void PauseGame() 
    {
        img.sprite = playBtn;
        isPaused = true;
    }

    public void ResumeGame()
    {
        img.sprite = pauseBtn;
        isPaused = false;
    }
}
