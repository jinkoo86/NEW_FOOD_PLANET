using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCRobber : MonoBehaviour {
    enum State {
        Search,
        Move,
        Avoid,
        Run,
        Die
    }
    State state;
    public Animator anim;

    GameObject targetObject;

    // - UI
    //public Slider sliderHP;
    // - 현재체력
    int curHP;
    // - 최대체력
    public int maxHP;

    public int HP {
        get { return curHP; }
        set {
            curHP = Mathf.Max(0, value);
            //sliderHP.value = curHP;
        }
    }
    //Avoid용
    float rightMax = 3.0f; //좌로 이동가능한 (x)최대값
    float leftMax = -3.0f; //우로 이동가능한 (x)최대값
    float currentPosition; //현재 위치(x) 저장
    float direction = 3.0f; //이동속도+방향

    public float speed = 5.0f;  //이동속도(public이라 인스펙터에서 적절한값으로 수정)
    Vector3 dir;                //이동할 방향

    // Start is called before the first frame update
    void Start() {
        maxHP = 3;
        state = State.Search;

        curHP = maxHP;
        //sliderHP.maxValue = maxHP;
        //sliderHP.value = curHP;
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Avoid: UpdateAvoid(); break;
            case State.Run: UpdateRun(); break;
            case State.Die: UpdateDie(); break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag== "ROBBERSPOT"){
            print(other.name);
            currentPosition = transform.position.x;
            state = State.Avoid;
        }
    }

    private void UpdateSearch() {
        targetObject = GameObject.Find("RobberSpot");
        //타겟이 null이 아니면
        if (targetObject != null) {
            //print(targetObject.name);
            //이동상태로 전이
            state = State.Move;
        }

    }
    private void UpdateMove() {
        dir = targetObject.transform.position - transform.position;
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
    }
    private void UpdateAvoid() { 
        currentPosition += speed * Time.deltaTime * direction;
        if (currentPosition >= rightMax) {
            direction *= -1;
            currentPosition = rightMax;
        }

        //현재 위치(x)가 우로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 우로 이동가능한 (x)최대값으로 설정

        else if (currentPosition <= leftMax) {
            direction *= -1;
            currentPosition = leftMax;
        }

        //현재 위치(x)가 좌로 이동가능한 (x)최대값보다 크거나 같다면
        //이동속도+방향에 -1을 곱해 반전을 해주고 현재위치를 좌로 이동가능한 (x)최대값으로 설정
        transform.position = new Vector3(currentPosition, transform.position.y, transform.position.z);
        //"Stone"의 위치를 계산된 현재위치로 처리
    }
    private void UpdateRun() {
    }
    private void UpdateDie() {
    }
}
