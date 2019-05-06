using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    JUMP,
    DEAD
}
public class PlayerFSMManager : MonoBehaviour {

    private Rigidbody2D rigi;
    public float distance = 5.0f; //raycast 길이
    public LayerMask boxMask;
    GameObject box;
    GameObject player;
    GameObject DogCheck;


    public PlayerState currentState;
    public PlayerState startState;

   
    public float moveSpeed;
    public float fallSpeed;


    public float xMove;

    public Collision col;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;
    

    private Vector2 moveDirection = Vector2.zero;
    private RaycastHit[] hits;
    public LayerMask checkLayer;
    //public Vector2 gravity = new Vector3(0, -10);


    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        moveSpeed = 2.5f;
        fallSpeed = -20.0f;

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");

  
        animator.SetBool("isWalking", false);

    }

    // Use this for initialization
    private void Start() {
        
        rigi = GetComponent<Rigidbody2D>();
    }



	// Update is called once per frame
	private void Update () {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);
  

        if(DogCheck.transform.position.x < transform.position.x)
        {
            moveSpeed = 4.0f;
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                mySpriteRenderer.flipX = true;

                animator.SetBool("isRunning", true);

                FindObjectOfType<AudioManager>().Play("Main_Walk");

                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                mySpriteRenderer.flipX = false;
                animator.SetBool("isRunning", true);
                FindObjectOfType<AudioManager>().Play("Main_Walk");
                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
            }
        }
        if (DogCheck.transform.position.x > transform.position.x)
        {
            moveSpeed = 2.5f;
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                mySpriteRenderer.flipX = true;
                FindObjectOfType<AudioManager>().Play("Main_Walk");
                animator.SetBool("isWalking", true);

                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                mySpriteRenderer.flipX = false;
                FindObjectOfType<AudioManager>().Play("Main_Walk");
                animator.SetBool("isWalking", true);
                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }
        
        //////////////////////////////////WALK//////////////////////////////////


        ////////////////////////////////////RUN///////////////////////////////////
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    moveSpeed = 3.0f;

        //    animator.SetBool("isRunning", true);

        //}
        //else if(Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //    moveSpeed = 2.5f;
        //    animator.SetBool("isRunning", false);
        //}
        ////////////////////////////////////RUN///////////////////////////////////

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKey(KeyCode.E))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
        }

        if(transform.position.y < -6)
        {
            player.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
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

