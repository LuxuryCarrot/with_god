using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogExtra : MonoBehaviour
{

    GameObject Sight;

    Animator ani;
    int movementFlag = 0;

    void Start()
    {
        ani = GetComponentInChildren<Animator>();
        StartCoroutine("DogState");

    }

    IEnumerator DogState()
    {
        movementFlag = Random.Range(0, 2);

        // idle
        if (movementFlag == 0)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
        }
        // eat
        else if (movementFlag == 1)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
        }

        yield return new WaitForSeconds(3f);

        StartCoroutine("DogState");
    }
}
