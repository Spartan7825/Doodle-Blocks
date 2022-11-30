using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Animator anim;

    public void OnClickedPlayBtn()
    {
        SceneManager.LoadScene("LvlSelection");
    }

    public void onClickedQuitBTn() 
    {
        Application.Quit();
        //Debug.Log("GameQuitting");
    }
    public void Update()
    {
        if (Input.touchCount >= 1) 
        {
            anim.speed = 10;
        }
        
    }
}
