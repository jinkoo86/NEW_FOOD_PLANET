using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    int itemTimmer=0;
    int itmeHeart=0;

    void HeartPlus() {

    }
    void TimerPlus() {

    }
    // Start is called before the first frame update
    void Start() {
        //

        if (itemTimmer == 1) {
            TimerPlus();
        }

        if (itmeHeart == 1) {
            HeartPlus();
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
