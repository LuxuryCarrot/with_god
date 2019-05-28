using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2PlayerMove : MonoBehaviour {

    public CameraMove camera;

    GameObject player;

    public float moveSpeed;
    public float fallSpeed;

    public Animator animator;
    public SpriteRenderer mySpriteRenderer;

    private Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {
        camera = GetComponent<CameraMove>();

        player = GameObject.FindGameObjectWithTag("Player");

        moveSpeed = 2.5f;
        fallSpeed = -20.0f;

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetBool("Walking", false);
    }

    void Start () {
		
	}
	
	void Update ()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0);

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            mySpriteRenderer.flipX = true;

            animator.SetBool("Walking", true);

            transform.Translate(new Vector2(moveDirection.x, 0));
        }
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            mySpriteRenderer.flipX = false;

            animator.SetBool("Walking", true);

            transform.Translate(new Vector2(moveDirection.x, 0));
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Walking", false);
        }
    }
}