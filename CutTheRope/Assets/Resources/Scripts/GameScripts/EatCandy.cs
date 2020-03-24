using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCandy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
            GameObject.Find("Manager").GetComponent<CutRope>().isLevelFinished = true;
            DataManager.dataManager.sounds[(int)DataManager.TypeSounds.endLevel].start();
        }
    }
}
