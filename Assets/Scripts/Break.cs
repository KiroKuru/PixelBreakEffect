using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject BreakEffect;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject BE=Instantiate(BreakEffect, transform.position, Quaternion.identity);
            BE.GetComponent<BreakEffect>().targetSprite = GetComponent<SpriteRenderer>().sprite;
            BE.GetComponent<BreakEffect>().Break();
            Destroy(gameObject);
        }
    }
}
