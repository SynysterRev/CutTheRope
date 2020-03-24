using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Candy"))
        {
            anim.SetTrigger("IsColliding");
            collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400.0f, ForceMode2D.Impulse);
        }
    }
}
