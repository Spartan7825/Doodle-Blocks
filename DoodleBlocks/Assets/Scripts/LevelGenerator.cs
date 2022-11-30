using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    int a = 0;
    Texture2DEditor t2d;
    // Start is called before the first frame update
    void Start()
    {

        t2d = FindObjectOfType<Texture2DEditor>();

        for (int i=0; i < gameObject.transform.childCount; i++)
        {
            if (!t2d.toShow.Contains(i))
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
/*
           // Random.seed = 1;
            a = Random.Range(1, 10);
            if (a < 6)
            {
                Destroy(gameObject.transform.GetChild(i).gameObject);
            }
*/
        }
        
        Debug.Log(t2d.toShow.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
