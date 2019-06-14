using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxMove : MonoBehaviour
{

    GameObject box;
    GameObject player;


    Rigidbody2D _rb;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        box = GameObject.FindGameObjectWithTag("Box");


        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;

    }

	
	void Update () {


        if (box.transform.position.y  > 9f)
        {
            Debug.Log("y > 11  ");
            _rb.isKinematic = false;
        }
        

    }


}
