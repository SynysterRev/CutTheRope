using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    Slider slider;
    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = DataManager.dataManager.SoundVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnChange()
    {
        DataManager.dataManager.ChangeSoundsVolume(slider.value);
    }
}
