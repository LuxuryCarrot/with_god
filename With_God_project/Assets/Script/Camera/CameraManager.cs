using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : CameraController
{
    GameObject player;
    GameObject DogCheck;
    GameObject subCamera;
    GameObject mainCamera;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        subCamera = GameObject.FindGameObjectWithTag("subCamera");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (transform.position.x == DogCheck.transform.position.x)
        {
            ShowSubCam();
        }

        else if (transform.position.x < DogCheck.transform.position.x)
        {
            ShowMainCam();
        }

        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    ShowSubCam();
        //}
    }
}