using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speedForce = 5.0f;
    public Vector2 jumpVector;
    private Rigidbody2D rigi;
    public bool isGrounded;
    public LayerMask ground;
    public float speed;
    public Transform grounder;
    public float radiuss;
    public float distance = 1.0f;

    public Animator animator;
    public SpriteRenderer mySpriteRenderer;
    // Use this for initialization
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            speed = isGrounded ? speedForce : speedForce * 0.8f;
            rigi.velocity = new Vector2(-speed, rigi.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("isWalking", true);
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            speed = isGrounded ? speedForce : speedForce * 0.8f;
            rigi.velocity = new Vector2(speed, rigi.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("isWalking", true);
            mySpriteRenderer.flipX = false;

        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else if (isGrounded)
        {
            rigi.velocity = new Vector2(0, rigi.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedForce = 1.0f;
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedForce = 0.5f;
            animator.SetBool("isRunning", false);
        }

        isGrounded = Physics2D.OverlapCircle(grounder.transform.position, radiuss, ground);


        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            rigi.AddForce(jumpVector, ForceMode2D.Force);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(grounder.transform.position, radiuss);


    }
}
