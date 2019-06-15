using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3PlayerMove : MonoBehaviour {

    //public CameraMove camera;


    GameObject Lantern;
    GameObject centi;

    public float moveSpeed;
    public float fallSpeed;

    public Animator animator;
    public SpriteRenderer mySpriteRenderer;


    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        //camera = GetComponent<CameraMove>();

        centi = GameObject.FindGameObjectWithTag("centi");
        Lantern = GameObject.FindGameObjectWithTag("Lantern");

        Lantern.GetComponent<SpriteRenderer>().enabled = false;

        fallSpeed = -20.0f;
        moveSpeed = 2.6f;

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetBool("Walking", false);
        animator.SetBool("push", false);
        animator.SetBool("pull", false);
    }

    void Start()
    {

    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            mySpriteRenderer.flipX = true;

            animator.SetBool("Walking", true);

            transform.Translate(new Vector2(moveDirection.x, 0));
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            mySpriteRenderer.flipX = false;

            animator.SetBool("Walking", true);

            transform.Translate(new Vector2(moveDirection.x, 0));
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Walking", false);
        }
        if (centi.transform.position.x > 244)
        {
            moveSpeed = 2.6f;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EventMaker_1")
        {
            Debug.Log("Entered");
            moveSpeed = 5.1f;
        }
    }
}
