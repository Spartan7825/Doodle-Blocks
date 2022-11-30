using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitLevel : MonoBehaviour
{
    [SerializeField] GameObject level1S;
    [SerializeField] GameObject level2S;
    [SerializeField] GameObject level3S;
    [SerializeField] GameObject level4S;
    [SerializeField] GameObject level5S;
    [SerializeField] GameObject level6S;
    [SerializeField] GameObject level7S;
    [SerializeField] GameObject level8S;
    [SerializeField] GameObject level9S;
    [SerializeField] GameObject level10S;
    [SerializeField] Sprite Locked;
    List<GameObject> levelGameobjects = new List<GameObject>();
    List<int> levelState = new List<int>();
    public void Start()
    {
        
        var level1 = PlayerPrefs.GetInt("level1", 1);
        var level2 = PlayerPrefs.GetInt("level2", 0);
        var level3 = PlayerPrefs.GetInt("level3", 0);
        var level4 = PlayerPrefs.GetInt("level4", 0);
        var level5 = PlayerPrefs.GetInt("level5", 0);
        var level6 = PlayerPrefs.GetInt("level6", 0);
        var level7 = PlayerPrefs.GetInt("level7", 0);
        var level8 = PlayerPrefs.GetInt("level8", 0);
        var level9 = PlayerPrefs.GetInt("level9", 0);
        var level10 = PlayerPrefs.GetInt("level10", 0);
        levelGameobjects.Add(level1S);
        levelGameobjects.Add(level2S);
        levelGameobjects.Add(level3S);
        levelGameobjects.Add(level4S);
        levelGameobjects.Add(level5S);
        levelGameobjects.Add(level6S);
        levelGameobjects.Add(level7S);
        levelGameobjects.Add(level8S);
        levelGameobjects.Add(level9S);
        levelGameobjects.Add(level10S);

        levelState.Add(level1);
        levelState.Add(level2);
        levelState.Add(level3);
        levelState.Add(level4);
        levelState.Add(level5);
        levelState.Add(level6);
        levelState.Add(level7);
        levelState.Add(level8);
        levelState.Add(level9);
        levelState.Add(level10);

        for (int i=0;i< levelState.Count;i++)
        {
            if (levelState[i] == 0)
            {
                levelGameobjects[i].GetComponent<Button>().interactable = false;
                levelGameobjects[i].GetComponent<Image>().sprite = Locked;
                levelGameobjects[i].transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                levelGameobjects[i].GetComponent<Button>().interactable = true;
            }
        }



    }


}
