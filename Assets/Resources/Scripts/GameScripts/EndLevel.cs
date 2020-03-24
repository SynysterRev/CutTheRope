using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] Button button;
    void Start()
    {
        button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Manager").GetComponent<CutRope>().isLevelFinished && !button.gameObject.activeSelf)
        {
            button.gameObject.SetActive(true);
        }
    }
}
