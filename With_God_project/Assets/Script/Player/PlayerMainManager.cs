using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainManager : MonoBehaviour {

    public PlayerMain manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        manager = GetComponent<PlayerMain>();
	}
}
