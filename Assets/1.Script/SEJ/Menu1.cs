using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu1 : MonoBehaviour
{
    bool menuYN;
    public GameObject menu;
    

    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "WaitingRoom")
        {
            if (OVRInput.Get(OVRInput.Button.Start))
            {
                //메뉴 UI가 false일 때 
                if (!menuYN)
                {
                    menu.SetActive(true);
                    print("켜짐");

                }
                //메뉴 UI가 true일 때
                else
                {
                    menu.SetActive(false);
                    print("꺼짐");
                }
            }
        }
        
    }
}
