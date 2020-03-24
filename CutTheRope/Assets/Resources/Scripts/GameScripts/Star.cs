using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public delegate void CollisionToDo();

    public CollisionToDo collisionToDo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Candy"))
        {
            collisionToDo();
            Destroy(gameObject);
        }
    }
}
