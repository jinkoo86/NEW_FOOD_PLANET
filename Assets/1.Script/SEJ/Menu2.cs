using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{
    bool menuYN;
    public GameObject menu2;
    
    void Start()
    {
        menu2.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StageRoom")
        {
            if (OVRInput.Get(OVRInput.Button.Start))
            {
                //메뉴 UI가 false일 때 
                if (!menuYN)
                {
                    menu2.SetActive(true);
                    print("켜짐");

                }
                //메뉴 UI가 true일 때
                else
                {
                    menu2.SetActive(false);
                    print("꺼짐");
                }
            }
        }
    }
}
