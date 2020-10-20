using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    public GameObject text;
    public GameObject soundManager;
    bool isText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickVol()
    {
        if (isText)
        {
            text.SetActive(true);
            soundManager.SetActive(true);
        }
        else
        {
            text.SetActive(false);
            soundManager.SetActive(false);
        }
    }

}
