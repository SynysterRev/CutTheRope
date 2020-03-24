using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posCam = Camera.main.WorldToViewportPoint(transform.position);
        if(posCam.x < -0.1f || posCam.y > 1.1f || posCam.y < -0.1f || posCam.y > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
