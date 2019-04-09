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

    public Collision col;
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

        animator.SetBool("isRunning", false);
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
            animator.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 0.5f;
            animator.SetBool("isRunning", false);
        }
        //////////////////////////////////RUN///////////////////////////////////

            
    }


    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    if (col.transform.tag == "Ground")
    //    {
    //        Debug.Log("바닥");
    //        this.transform.Translate(new Vector2(moveDirection.x, 10));
    //    }
    //}
}

