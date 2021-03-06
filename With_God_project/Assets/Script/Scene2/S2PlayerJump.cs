﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2PlayerJump : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rigi;
    public float JumpPower = 4f;

    private Transform _transform;
    private bool _isJumping;
    private bool _isGrounded;
    private float _posY;        //오브젝트의 초기 높이
    public float _gravity;     //중력가속도
    public float _jumpPower;   //점프력
    private float _jumpTime;    //점프 이후 경과시간

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Jumping", false);
        rigi = GetComponent<Rigidbody2D>();
        _transform = transform;
        _isGrounded = false;
        _posY = transform.position.y;
        _gravity = 20.0f;
        _jumpPower = 8.2f;
        _jumpTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping && _isGrounded)
        {
            animator.SetBool("Jumping", true);

            _posY = _transform.position.y;

            Jump();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jumping", false);
        }

        
    }

    //void Jump()
    //{
    //    //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
    //    //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
    //    //변화된 높이 height를 기존 높이 _posY에 더한다.
    //    float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
    //    _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
    //    //점프시간을 증가시킨다.
    //    _jumpTime += Time.deltaTime;

    //    //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
    //    if (height < 0.0f)
    //    {
    //        _isJumping = false;
    //        _jumpTime = 0.0f;
    //        _transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
    //    }
    //}

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
