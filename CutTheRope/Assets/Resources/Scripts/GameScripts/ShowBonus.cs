using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBonus : MonoBehaviour
{
    Image[] images;
    // Use this for initialization
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++)
        {
            images[i].enabled = false;
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject.Find("Star" + (1 + i)).GetComponent<Star>().collisionToDo = ChangeImageBonus;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeImageBonus()
    {
        DataManager.dataManager.sounds[(int)DataManager.TypeSounds.star].start();
        images[CutRope.numberStars].enabled = true;
        CutRope.numberStars++;
    }

}
