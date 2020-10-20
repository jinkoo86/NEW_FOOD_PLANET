using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    public GameObject menu;
    LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitinfo;
        lr.SetPosition(0, transform.position);
        if (Physics.Raycast(ray, out hitinfo))
        {
            if (hitinfo.transform.gameObject.name.Contains("Volume"))
            {
                print(hitinfo + "Volume");
            }
            else if (hitinfo.transform.gameObject.name.Contains("Vibration"))
            {
                print(hitinfo + "Vibration");
            }
            else if (hitinfo.transform.gameObject.name.Contains("Close"))
            {
                print(hitinfo + "Close");
                menu.SetActive(false);
            }
        }
    }
}
