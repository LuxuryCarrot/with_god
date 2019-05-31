using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    GameObject Stone;
    GameObject Player;
    GameObject StoneTower;

	// Use this for initialization
	void Start () {
        Stone = GameObject.FindGameObjectWithTag("Stone");
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
