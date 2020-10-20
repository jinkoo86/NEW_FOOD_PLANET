using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCustomer : MonoBehaviour {
    enum State {
        Search,
        Move,
        Order,
        Good,
        Bad
    }
    State state;

    public float speed = 5.0f;  //이동속도(public이라 인스펙터에서 적절한값으로 수정)
    Vector3 dir;                //이동할 방향

    public Animator anim;
    GameObject targetObject;
    GameObject tempObject;

    public float currentTime;

    void Start() {
        state = State.Search;
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Order: UpdateOrder(); break;
            case State.Good: UpdateGood(); break;
            case State.Bad: UpdateBad(); break;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "COUNTER") {
            //print(other.name);
            state = State.Order;
        }
        if(other.tag == "EXIT") {
            //print("exit 진입");
            NPCSpawnManager.Instance.TableList.Add(tempObject);
            GameObject.Destroy(gameObject);
        }
    }

    // - 목적지를 찾는 상태
    private void UpdateSearch() {
        //print("서치진입");
        targetObject = NPCSpawnManager.Instance.TableList[(Random.Range(0, NPCSpawnManager.Instance.TableList.Count))];
        //print("손님 생성, 위치:" + targetObject.name);
        NPCSpawnManager.Instance.TableList.Remove(targetObject);
        tempObject = targetObject;
        //print("남은번호:" + NPCSpawnManager.Instance.TableList.Count);
        //타겟이 null이 아니면
        if (targetObject != null) {
            //print(targetObject.name);
            //이동상태로 전이
            state = State.Move;
        }
    }
    // - 이동하는 상태
    private void UpdateMove() {
       // print("무브진입");
        //customer의 목적지를 타겟으로
        dir = targetObject.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
    private void UpdateOrder() {
        //print("오더진입");
        //도착하면 그자리에 정지 후
        //랜덤돌려서 주문
        //근데 그냥 테스트용도로 1초뒤에 돌아가게
        currentTime += Time.deltaTime;
        if (currentTime > 1f) {
            targetObject = GameObject.Find("EXIT");
            state = State.Move;
        }
    }
    private void UpdateGood() {
        //돈 올리고
        //좋은 애니메이션
        //start에서 지웠던 list 다시 추가
        NPCSpawnManager.Instance.TableList.Add(tempObject);
        //포탈로 돌아가야하므로 타겟오브젝트 포탈로
        //그러고 이동
        //state = State.Move;
    }
    private void UpdateBad() {
        //컴플레인 올리고
        //나쁜 애니메이션
        //start에서 지웠던 list 다시 추가
        NPCSpawnManager.Instance.TableList.Add(tempObject);
        //포탈로 돌아가야하므로 타겟오브젝트 포탈로
        //그러고 이동
        //state = State.Move;
    }
}


