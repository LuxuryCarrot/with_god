using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start () {
		
	}
	
	void Update () {
		
        if (Player.transform.position.x >= 54)
        {
            transform.Translate(200f * Time.deltaTime, 0, 0);

        }

	}
}
