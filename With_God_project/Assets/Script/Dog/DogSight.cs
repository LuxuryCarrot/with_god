using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DogSight : MonoBehaviour
{
    public Animator anim;
    public bool judge;
    public GameObject sight;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        judge = GetComponent<Animator>();
    }

    void Start () {
		
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z))
            sight.SetActive(false);
		
	}
}