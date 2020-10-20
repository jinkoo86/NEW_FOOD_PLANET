using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTSCRIPT : MonoBehaviour {
    GameObject targetObject;
    // Start is called before the first frame update
    void Start() {
        targetObject = GameObject.FindWithTag("COUNTER");
    }

    // Update is called once per frame
    void Update() {
    }
}
