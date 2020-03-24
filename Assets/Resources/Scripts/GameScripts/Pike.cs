using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        DataManager.dataManager.sounds[(int)DataManager.TypeSounds.electricity].start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
