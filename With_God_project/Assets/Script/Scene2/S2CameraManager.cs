using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2CameraManager : CameraController
{
    GameObject Player;
    GameObject Temple;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Temple = GameObject.FindGameObjectWithTag("Wall");
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (Player.transform.position.x >= Temple.transform.position.x)
        {
            ShowSubCam();
        }

        else if (Player.transform.position.x < Temple.transform.position.x)
        {
            ShowMainCam();
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    ShowSubCam();
        //}
    }
}
