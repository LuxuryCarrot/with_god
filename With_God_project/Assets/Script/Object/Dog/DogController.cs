using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour {

    GameObject Sight;
    
    public float SightSpeed = 1.0f;

    Animator ani;
    int movementFlag = 0;

    private void Awake()
    {
        Sight = GameObject.FindGameObjectWithTag("Sight");
        Sight.SetActive(false);
    }
    void Start() {
        ani = GetComponentInChildren<Animator>();
        StartCoroutine("DogState");

    }

    IEnumerator DogState()
    {
        movementFlag = Random.Range(0, 5);

        // idle
        if (movementFlag == 0)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
            Sight.SetActive(false);
        }
        // eat
        else if(movementFlag == 1)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
            Sight.SetActive(false);
        }
        // look_front
        else if(movementFlag == 2)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
            Sight.SetActive(true);
        }
        // look_side
        else if(movementFlag == 3)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
            Sight.SetActive(false);
        }
        // stare
        else if(movementFlag == 4)
        {
            ani.SetInteger("FLAG", (int)movementFlag);
            Sight.SetActive(true);
        }

        yield return new WaitForSeconds(3f);

        StartCoroutine("DogState");
    }

 
}
