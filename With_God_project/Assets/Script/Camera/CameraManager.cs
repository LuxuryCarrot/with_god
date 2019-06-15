using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : CameraController
{
    GameObject DogCheck;
    GameObject Player;
    GameObject Tree;
    
    private void Awake()
    {
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        Player = GameObject.FindGameObjectWithTag("Player");
        Tree = GameObject.FindGameObjectWithTag("Finish");
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if ((Player.transform.position.x >= DogCheck.transform.position.x) && (Player.transform.position.x <= Tree.transform.position.x))
        {
            ShowSubCam();
        }

        else//if (Player.transform.position.x < DogCheck.transform.position.x)
        {
            ShowMainCam();
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    ShowSubCam();
        //}
    }
}