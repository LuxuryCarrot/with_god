using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCheck : MonoBehaviour {
    GameObject Doggie;
    GameObject DCheck;
    // Use this for initialization
    private void Start()
    {
        Doggie = GameObject.FindGameObjectWithTag("ChaseDog");
        DCheck = GameObject.FindGameObjectWithTag("DogCheck");
    }
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            DCheck.SetActive(false);
            Doggie.transform.Translate(new Vector2(0, -13.12f));
        }
    }
}
