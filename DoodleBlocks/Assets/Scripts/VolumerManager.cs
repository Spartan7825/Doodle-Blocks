using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumerManager : MonoBehaviour
{
    //private AudioSource[] mysounds;

    private AudioSource bg;
    public  static bool volTrigger;

    public GameObject volumeBtn;
    public GameObject volumeMuteBtn;
    
    void Start()
    {
        if (!volTrigger)
        {
            unmuteVol();
        }
        else 
        {
            muteVol();
        }
        //mysounds = GetComponents<AudioSource>();

        //bg = mysounds[0];
    }
    public void muteVol()
    {
            AudioListener.volume = 0;
            volumeBtn.SetActive(false);
            volumeMuteBtn.SetActive(true);
            volTrigger = true;
    }
    public void unmuteVol() 
    {
            volumeMuteBtn.SetActive(false);
            AudioListener.volume = 0.75f;
            volumeBtn.SetActive(true);
            volTrigger = false;
    }
    public void update() 
    {

    }
/*    public void playBGSound()
    {
        bg.Play();
    }*/

}
