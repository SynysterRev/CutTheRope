using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] string nameScene;
    [SerializeField] int nextScene;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        if (nameScene != "Quit")
        {
            if (SceneManager.GetActiveScene().name == "Options")
            {
                DataManager.dataManager.SaveSoundData();
            }
            DataManager.dataManager.sounds[(int)DataManager.TypeSounds.button].start();
            SceneManager.LoadScene(nameScene);
            DataManager.dataManager.ChangeMusic(nextScene);
        }
        else
        {
            Application.Quit();
        }
    }
}
