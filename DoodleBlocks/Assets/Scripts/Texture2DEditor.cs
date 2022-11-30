using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texture2DEditor : MonoBehaviour
{
    Texture2D t2d;
    public List<int> toShow;


    private void Awake()
    {
        var rawImage = GetComponent<RawImage>();
        t2d = rawImage.texture as Texture2D;
        var pixelData = t2d.GetPixels();
        int a = pixelData.Length / 400;

        for (int i = 0; i < pixelData.Length; i++)
        {
            if (pixelData[i].grayscale < 0.6)
            {
                if (!toShow.Contains((int)i / a))
                {
                    toShow.Add((int)i / a);
                }
                // Debug.Log( );
            }

            // Debug.Log(pixelData[i].grayscale);
        }

        //  print("Total pixels " + pixelData.Length);

    }


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
