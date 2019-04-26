using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    void Start () {
		
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShowMainCam();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            ShowSubCam();
        }
    }

    void ShowMainCam()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    void ShowSubCam()
    {
        mainCamera.enabled = false;
        subCamera.enabled = true;
    }
}
