using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera subCamera;

    public void ShowMainCam()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    }

    public void ShowSubCam()
    {
        mainCamera.enabled = false;
        subCamera.enabled = true;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}