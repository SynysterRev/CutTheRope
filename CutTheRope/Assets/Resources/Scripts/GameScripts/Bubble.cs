using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    bool haveACandy;
    Vector2 force;
    GameObject heldObject;
    void Start()
    {
        haveACandy = false;
        force = Vector2.up;
        heldObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveACandy)
        {
            transform.position = heldObject.transform.position;
            heldObject.GetComponent<Rigidbody2D>().velocity = force * 2.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Candy") && !haveACandy)
        {
            haveACandy = true;
            transform.parent = collision.transform;
            heldObject = collision.gameObject;
            heldObject.transform.position = transform.position;
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
