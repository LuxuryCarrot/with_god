﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : CameraController
{
    GameObject DogCheck;
    GameObject Player;
    
    private void Awake()
    {
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Player.transform.position.x >= DogCheck.transform.position.x)
        {
            ShowSubCam();
        }

        else if (Player.transform.position.x < DogCheck.transform.position.x)
        {
            ShowMainCam();
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    ShowSubCam();
        //}
    }
}