using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2CameraManager : CameraController
{
    GameObject Player;
    GameObject Temple_in;
    GameObject Temple_out;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Temple_in = GameObject.FindGameObjectWithTag("Wall");
        Temple_out = GameObject.FindGameObjectWithTag("wall2");
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if ((Temple_out.transform.position.x >= Player.transform.position.x) && (Player.transform.position.x >= Temple_in.transform.position.x))
        {
            ShowSubCam();
        }

        else
        {
            ShowMainCam();
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    ShowSubCam();
        //}
    }
}
