using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCamera : MonoBehaviour {
    GameObject Player;
    GameObject MainCamera;
    GameObject SCamera;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        MainCamera = GameObject.FindGameObjectWithTag("MCamera");
        SCamera = GameObject.FindGameObjectWithTag("StartCamera");
    }
    private void Update()
    {
        if (Player.transform.position.x < -2)
        {
            Player.transform.Translate(new Vector2(1 * 6.0f * Time.deltaTime, 0));
        }
        if (Player.transform.position.x >= -2)
        {
            MainCamera.SetActive(true);
            SCamera.SetActive(false);
        }
    }
}
