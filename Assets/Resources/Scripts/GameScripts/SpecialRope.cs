using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRope : MonoBehaviour
{
    [SerializeField] GameObject prefabsLink;
    [SerializeField] float sizeLink;
    bool hasCreateARope;
    GameObject lastLink;

    public GameObject LastLink
    {
        get
        {
            return lastLink;
        }
    }



    // Use this for initialization
    void Start()
    {
        hasCreateARope = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateRope(GameObject candy)
    {

        float distance = Vector2.Distance(candy.transform.position, transform.position);

        int nbLink = (int)(distance / (sizeLink * 0.15f));
        Vector3 direction = candy.transform.position - transform.position;
        direction.Normalize();
        Rigidbody2D previousRb = GetComponent<Rigidbody2D>();
        GameObject rope = new GameObject();
        rope.name = "rope";
        rope.transform.parent = this.transform;
        for (int i = 0; i < nbLink; i++)
        {
            GameObject link = Instantiate(prefabsLink, transform.position, Quaternion.identity, rope.transform);
            Vector2 scale = link.transform.localScale;
            scale.y = sizeLink;
            link.transform.localScale *= scale;
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            if (i == 0)
            {
                link.transform.localPosition = new Vector3(link.transform.localPosition.x + 0.01f, link.transform.localPosition.y - 0.01f, link.transform.localPosition.z);
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = new Vector2(0.0f, 0.0f);
            }
            else
            {
                link.transform.localPosition = new Vector3(link.transform.localPosition.x + 0.01f, link.transform.localPosition.y - i * sizeLink * 0.19f, link.transform.localPosition.z);
            }
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation += 90.0f;
            joint.connectedBody = previousRb;
            previousRb = link.GetComponent<Rigidbody2D>();
            link.transform.RotateAround(transform.position, Vector3.forward, rotation);
            if (i == nbLink - 1)
            {
                lastLink = link;
                HingeJoint2D candyJoint = candy.AddComponent<HingeJoint2D>();
                candyJoint.autoConfigureConnectedAnchor = false;
                candyJoint.connectedBody = previousRb;
                candyJoint.anchor = new Vector2(0.0f, 2.0f);
                candyJoint.connectedAnchor = new Vector2(0.0f, -0.23f * sizeLink);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCreateARope && collision.CompareTag("Candy"))
        {
            CreateRope(collision.gameObject);
            hasCreateARope = true;
        }
    }
}
