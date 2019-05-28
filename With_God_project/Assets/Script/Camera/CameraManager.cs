using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : CameraController
{
    GameObject DogCheck;
    
    private void Awake()
    {
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
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