using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [SerializeField] GameObject dataManager;
    // Use this for initialization
    void Start()
    {
        if(DataManager.dataManager == null)
        {
            Instantiate(dataManager);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
