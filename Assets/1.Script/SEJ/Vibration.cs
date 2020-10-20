using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour
{
    public GameObject vibrationManager;
    public GameObject text;
    bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVibration()
    {
        if (isOn)
        {
            text.SetActive(true);
            vibrationManager.SetActive(true);
        }
        else
        {
            text.SetActive(false);
            vibrationManager.SetActive(false);
        }
    }
}
