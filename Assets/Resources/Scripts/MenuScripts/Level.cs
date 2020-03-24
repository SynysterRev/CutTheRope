using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    bool isUnlocked;
    [SerializeField] int indexLevel;
    [SerializeField] Image image;
    // Use this for initialization
    void Start()
    {
        isUnlocked = DataManager.dataManager.levelUnlocked[indexLevel];
        GetComponent<Button>().interactable = isUnlocked;
        image.gameObject.SetActive(!isUnlocked);
        if (isUnlocked)
        {
            Image[] images = GetComponentsInChildren<Image>();
            for (int i = 0; i < DataManager.dataManager.starPerLevel[indexLevel] + 1; i++)
            {
                if (images[i].gameObject.GetInstanceID() != GetInstanceID())
                {
                    images[i].enabled = true;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
