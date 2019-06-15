using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite_start : MonoBehaviour {

    GameObject Player;
    GameObject Stalactite_s;
    GameObject Lantern;

	// Use this for initialization
	void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Stalactite_s = GameObject.FindGameObjectWithTag("Stalactite_s");
        Lantern = GameObject.FindGameObjectWithTag("Lantern");
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.x > Stalactite_s.transform.position.x + 14 && Stalactite_s.transform.position.y > -4f)
        {
            transform.Translate(new Vector2(0, -0.2f));
        }
       
	}
}
