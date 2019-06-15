using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3PlayerJ : MonoBehaviour {

    public Animator animator;

    Rigidbody2D rigi;
    public float JumpPower = 4f;



    private bool _isGrounded;

    public float _gravity;     //중력가속도
    public float _jumpPower;   //점프력

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Jumping", false);
        rigi = GetComponent<Rigidbody2D>();
        _isGrounded = false;
        _gravity = 20.0f;
        _jumpPower = 8.2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)  && _isGrounded)
        {
            animator.SetBool("Jumping", true);


            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jumping", false);
        }


    }

    void Jump()
    {

        rigi.velocity = Vector3.zero;

        Vector3 jumVelocity = new Vector3(0, JumpPower, 0);
        rigi.AddForce(jumVelocity, ForceMode2D.Impulse);

        _isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Box_r")
        {
            _isGrounded = true;
        }

    }
}
