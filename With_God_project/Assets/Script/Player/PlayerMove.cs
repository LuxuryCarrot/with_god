using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour {
    public float xMove; // Player의 X 축 이동 
    public float yMove; // Player의 Y축 이동
    public float fallSpeed; // Player의 떨어지는 속도
    public float moveSpeed; // Player의 이동 속도

    public LayerMask boxMask; // Box의 레이어 마스크
    public Collision col;              // 충돌을 나타냄
    public Animator animator;    // 애니메이션 관리
    public SpriteRenderer mySpriteRenderer; // 스프라이트 렌더링 관리

    Vector2 testboxpos;
   
    public GameObject box; // "Box" 태그를 가져오기위해 게임 오브젝트 box를 선언

    private Rigidbody2D rigi; //

    private void Awake()
    {
        box.tag = "Box";
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        testboxpos = box.transform.position;
        Debug.Log(testboxpos);
  
    }
}
