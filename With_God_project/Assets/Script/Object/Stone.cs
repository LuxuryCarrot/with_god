using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    GameObject PlayerObj;
    GameObject StoneObj;
	// Use this for initialization
	void Start () {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        StoneObj = GameObject.FindGameObjectWithTag("Stone");
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
