using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    JUMP,
    DEAD
}
public class PlayerFSMManager : MonoBehaviour {

    public PlayerState currentState;
    public PlayerState startState;
    public CharacterController cc;
    public float moveSpeed;
    public float fallSpeed;


    public float xMove;
    
    
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;

    private Vector2 moveDirection = Vector2.zero;
    //public Vector2 gravity = new Vector3(0, -10);
    bool isJumping;


    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();

    private void Awake()
    {
        moveSpeed = 0.5f;
        fallSpeed = -20.0f;
        cc = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        states.Add(PlayerState.IDLE, GetComponent<Player_S>());
        states.Add(PlayerState.RUN, GetComponent<Player_R>());
    }
    public void SetState(PlayerState newState)
    {
        foreach (PlayerFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }
       
        states[newState].enabled = true;
        currentState = newState;
    }
    // Use this for initialization
    private void Start() {

        SetState(startState);

    }



	// Update is called once per frame
	private void Update () {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection *= moveSpeed;
        //////////////////////////////////WALK//////////////////////////////////

        //if(collision.transform.tag == "Ground")//땅에 접촉한 동안에 실행됨
        //{
        //    this.isGrounded = true;
        //    this.player.transform.position = Vector2.zero;

        //}

        //if (collision.transform.tag == "Ground")//땅에서 탈출한 시점에 실행됨
        //{
        //    this.isGrounded = false;
        //    this.dir.y -= this.gravity * Time.deltaTime;

        //}

        //this.player.transform.Translate(this.dir * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            mySpriteRenderer.flipX = true;
            animator.SetBool("isWalking", true);

            transform.Translate(new Vector2(moveDirection.x, 0));
        }                                                                     
        if(Input.GetAxisRaw("Horizontal") > 0)                                
        {                                                                     
            mySpriteRenderer.flipX = false;                                   
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector2(moveDirection.x, 0));
        }                                                                     
        if(Input.GetAxisRaw("Horizontal") == 0)                               
        {
            animator.SetBool("isWalking", false);
            SetState(PlayerState.IDLE);
        }
        //////////////////////////////////WALK//////////////////////////////////


        //////////////////////////////////RUN///////////////////////////////////
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 1.0f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 0.5f;
        }
        //////////////////////////////////RUN///////////////////////////////////


        //////////////////////////////////JUMP///////////////////////////////////
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Jump!");
        //    Jump();
            
        //    transform.Translate(new Vector2(moveDirection.x, maxJumpHeight * Time.deltaTime));
        //}
        //////////////////////////////////JUMP///////////////////////////////////

        //moveDirection.y -= gravity * Time.deltaTime;    //ERROR
        //cc.Move(moveDirection * Time.deltaTime);
    }

    //public void Jump()
    //{
    //    if(this.isGrounded)
    //    {
    //        this.dir.y = this.maxJumpHeight;
    //    }
    //}

    

}
