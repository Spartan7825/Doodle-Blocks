using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField]private Material material;
    private float dissolveAmount;
    private bool isDissolving;
    [SerializeField]private float dissolveSpeed = 5f;

    public void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDissolving)
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount + Time.deltaTime*dissolveSpeed);
            material.SetFloat("_DissolveAmount", dissolveAmount);
        }
        else
        {
            dissolveAmount = Mathf.Clamp01(dissolveAmount - Time.deltaTime*dissolveSpeed);
            material.SetFloat("_DissolveAmount", dissolveAmount);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("key pressed");
            isDissolving = true;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            isDissolving = false;
        }
    }

    public void SetIsDissolving()
    {
        isDissolving = true;
    }

    public bool GetDissolveAmount()
    {
        return dissolveAmount >= 1;
       
    }
}
