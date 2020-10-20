using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnManager : MonoBehaviour {

    public static NPCSpawnManager Instance;
    float currentTime;
    public float createTime = 2f; //(public이라 인스펙터에서 적절한값으로 수정)

    public List<GameObject> TableList = new List<GameObject>();
    public bool emptyTableList1, emptyTableList2, emptyTableList3, emptyTableList4, emptyTableList5;
    public GameObject npcCustomer;
    public GameObject npcRobber;
    //10퍼센트의 확률로 강도 출현
    public int rndValue = 10;

    public void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        //이런식으로 bool 비교로 바꿔야함 기존 list 뺏다 꼇다 하는거는 나중에 문제생길듯
        emptyTableList1 = true;
        emptyTableList2 = true;
        emptyTableList3 = true;
        emptyTableList4 = true;
        emptyTableList5 = true;
    }

    // Update is called once per frame
    void Update() {
        if (TableList.Count!= 0) {
            currentTime += Time.deltaTime;
            //만약 손님수가 5명이상이 아니면
            if (currentTime >= createTime) {
                //NPC를 생산하는데
                //랜덤하게 해서 어느정도면 고객이고
                //if (rndValue > 2) {
                //    GameObject customer = Instantiate(npcCustomer);
                //    customer.transform.position = transform.position;
                //    currentTime = 0;
                //}
                ////아니면 강도인데
                //else {
                    GameObject robber = Instantiate(npcRobber);
                    robber.transform.position = transform.position;
                    currentTime = 0;
                //}
            }

        }
    }
}
