﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S3CameraMove : MonoBehaviour
{
    // 카메라 흔들림 효과
    //public float shakeTimer;
    //public float shakeAmount;

    float characterPosition = 5.0f;

    private Vector2 velocity;

    private float smoothTimeX = 0.0f;
    private float smoothTimeY = 0.0f;

    public GameObject player;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + characterPosition, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        //if ((player.transform.position.x >= 52.0f) && (player.transform.position.x <= 240.0f))
        //{
        //    ShakeCamera(0.1f, 0.08f);
        //}

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

        //private void Update()
        //{
        //    if(shakeTimer >= 0)
        //    {
        //        Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
        //        transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
        //        shakeTimer -= Time.deltaTime;
        //    }
        //}

        //public void ShakeCamera(float shakePwr, float shakeDur)
        //{
        //    shakeAmount = shakePwr;
        //    shakeTimer = shakeDur;
        //}
}