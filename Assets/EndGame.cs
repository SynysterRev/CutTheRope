using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Image image;
    void Start()
    {
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Manager").GetComponent<CutRope>().isLevelFinished && !image.gameObject.activeSelf)
        {
            image.gameObject.SetActive(true);
        }
    }
}
