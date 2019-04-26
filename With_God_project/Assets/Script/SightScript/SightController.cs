using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightController : MonoBehaviour {

    public float SightSpeed = 1.0f;

    Animator ani;
    int movementFlag = 0;

    void Start() {
        ani = GetComponent<Animator>();

        StartCoroutine("DogState");

    }

    //IEnumerator DogState()
    //{
    //    movementFlag = Random.Range(0, 3);

    //    if (movementFlag == 0)
    //    {
    //        ani.setBool
    //    }
    //}

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (movementFlag == 1)
        {
            moveVelocity = Vector3.left;
        }
        else if(movementFlag == 2)
        {
            moveVelocity = Vector3.right;
        }

    }


 
}
