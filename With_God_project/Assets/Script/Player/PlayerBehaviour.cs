using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    public float PlayerxMove;             // Player오브젝트의 X축 움직임
    public float PlayeryMove;             // Player오브젝트의 Y축 움직임
    public float PlayerMoveSpeed;     // Player오브젝트의 움직임 속도
    public float PlayerGravity;        // Player 오브젝트의 중력가속도
    public float distance = 1.0f;         // RayCast선 길이 

    private Collision PlayerCollision;            // 충돌체크
    private Animator PlayerAnimator;   // 애니메이션 관리
    private SpriteRenderer PlayerSpriteRenderer; // 스프라이트 렌더링 관리
    private Vector2 PlayerMoveDirection = Vector2.zero; // Player (x, y) 좌표값 초기화
    private LayerMask BoxMask;       // 레이캐스팅으로 게임 오브젝트를 판별하는데 사용됨
    private LayerMask GroundMask;
    private RaycastHit2D PlayerFindObj; // 플레이어가 오브젝트와 충돌하였을때 오브젝트를 판별하기 위해 사용함
    private GameObject Box;
    private GameObject Ground;

    private void Awake()
    {
        PlayerMoveSpeed = 2.5f;

        PlayerAnimator = GetComponent<Animator>();
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();

        PlayerAnimator.SetBool("isWalking", false);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //////////////////////////////////MOVEDIRECTION//////////////////////////////////
        PlayerMoveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * PlayerMoveSpeed * Time.deltaTime, 0);
        //////////////////////////////////MOVEDIRECTION//////////////////////////////////

        //////////////////////////////////RAY//////////////////////////////////
        Physics2D.queriesStartInColliders = false; // 콜라이더 2D 안에서 시작된 물리 쿼리가 시작된 콜라이더를 감지할 수 있습니다.
        PlayerFindObj = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, BoxMask);


        if (PlayerFindObj.collider != null)
        {

        }
        //////////////////////////////////RAY//////////////////////////////////

        //////////////////////////////////WALK//////////////////////////////////
        if (Input.GetAxisRaw("Horizontal") <0)
        {
            PlayerSpriteRenderer.flipX = true;
            PlayerAnimator.SetBool("isWalking", true);
            transform.Translate(new Vector2(PlayerMoveDirection.x, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            PlayerSpriteRenderer.flipX = false;
            PlayerAnimator.SetBool("isWalking", true);
            transform.Translate(new Vector2(PlayerMoveDirection.x, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            PlayerAnimator.SetBool("isWalking", false);
        }
        //////////////////////////////////WALK//////////////////////////////////


        //////////////////////////////////RUN//////////////////////////////////
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerMoveSpeed = 5.0f;

            PlayerAnimator.SetBool("isRunning", true);

        } 
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerMoveSpeed = 2.5f;
            PlayerAnimator.SetBool("isRunning", false);
        }
        //////////////////////////////////RUN//////////////////////////////////


        //////////////////////////////////JUMP//////////////////////////////////




        //////////////////////////////////JUMP//////////////////////////////////



        
    }
    //////////////////////////////////GIZMO//////////////////////////////////
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
     
    //////////////////////////////////GIZMO//////////////////////////////////
}
