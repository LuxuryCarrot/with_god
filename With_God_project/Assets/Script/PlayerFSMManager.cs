using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFSMManager : MonoBehaviour {

    AudioSource Walk_Main;
    GameObject player;
    GameObject DogCheck;
    GameObject Godtree; // 당산나무
    
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



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Godtree = GameObject.FindGameObjectWithTag("Finish");

        fallSpeed = -20.0f;

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        Walk_Main = GetComponent<AudioSource>();
    
        animator.SetBool("isWalking", false);
    }

    // Use this for initialization
    private void Start() {
        


    }



	// Update is called once per frame
	private void Update () {

       

        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);
  

        if(DogCheck.transform.position.x < transform.position.x)
        {
            moveSpeed = 2.5f;
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                mySpriteRenderer.flipX = true;

                animator.SetBool("isRunning", true);
                Walk_Main.Play();
                //FindObjectOfType<AudioManager>().Play("Main_Walk");

                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                mySpriteRenderer.flipX = false;
                animator.SetBool("isRunning", true);
                Walk_Main.Play();
                //FindObjectOfType<AudioManager>().Play("Main_Walk");
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
            moveSpeed = 1f;
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                mySpriteRenderer.flipX = true;
                //FindObjectOfType<AudioManager>().Play("Main_Walk");
                Walk_Main.Play();
                animator.SetBool("isWalking", true);

                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                mySpriteRenderer.flipX = false;
                //FindObjectOfType<AudioManager>().Play("Main_Walk");
                Walk_Main.Play();
                animator.SetBool("isWalking", true);
                transform.Translate(new Vector2(moveDirection.x, 0));
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }

        // 당산나무 지났을 시
        if (transform.position.x >= Godtree.transform.position.x)
        {
            moveSpeed = 1f;
            animator.SetBool("isRunning", false);

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                mySpriteRenderer.flipX = true;
                animator.SetBool("isWalking", true);
            }

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                mySpriteRenderer.flipX = false;
                animator.SetBool("isWalking", true);
            }

            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
        }
    }
}

