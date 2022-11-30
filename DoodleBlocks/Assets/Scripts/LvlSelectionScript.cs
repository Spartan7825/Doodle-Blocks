using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlSelectionScript : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    public void OnClickedCloseBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickedLvl1Btn() 
    {
        SceneManager.LoadScene("Level(1)");
    }
    public void OnClickedLvl2Btn()
    {
        SceneManager.LoadScene("Level(2)");
    }
    public void OnClickedLvl3Btn()
    {
        SceneManager.LoadScene("Level(3)");
    }
    public void OnClickedLvl4Btn()
    {
        SceneManager.LoadScene("Level(4)");
    }
    public void OnClickedLvl5Btn()
    {
        SceneManager.LoadScene("Level(5)");
    }
    public void OnClickedLvl6Btn()
    {
        SceneManager.LoadScene("Level(6)");
    }
    public void OnClickedLvl7Btn()
    {
        SceneManager.LoadScene("Level(7)");
    }
    public void OnClickedLvl8Btn()
    {
        SceneManager.LoadScene("Level(8)");
    }
    public void OnClickedLvl9Btn()
    {
        SceneManager.LoadScene("Level(9)");
    }
    public void OnClickedLvl10Btn()
    {
        SceneManager.LoadScene("Level(10)");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 1)
        {
            anim.speed = 10;
            anim2.speed = 10;
        }
    }
}
