using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMain : MonoBehaviour {
    public float JumpForce;
    public float MoveSpeed;
    public float fallSpeed;
    
    public float xMove;
    public float yMove;

    public Collision col;
    public Animator animator;
    public SpriteRenderer mySpriteRenderer;

    public Vector2 moveDirection = Vector2.zero;

    private void Awake()
    {

        MoveSpeed = 0.5f;
        fallSpeed = -20.0f;

        animator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetBool("isStanding", true);

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        moveDirection = 
            new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed * Time.deltaTime, 0);

	}
}
