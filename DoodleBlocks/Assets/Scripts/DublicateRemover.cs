using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DublicateRemover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    List<Vector3> pos = new List<Vector3>();
    void Start()
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (!pos.Contains(parent.transform.GetChild(i).transform.position))
            {
                pos.Add(parent.transform.GetChild(i).position);
            }
            else 
            {
                Debug.Log(parent.transform.GetChild(i).name);
                Destroy(parent.transform.GetChild(i).gameObject); 
            }
            
        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
