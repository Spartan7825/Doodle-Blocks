using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSkipper : MonoBehaviour
{
    public Animator animatorToSkip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //Input.touchCount > 0
        {
            Debug.Log("Space pressed");
            //animatorToSkip
        }
    }
}
