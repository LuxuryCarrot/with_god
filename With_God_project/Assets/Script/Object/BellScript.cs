using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScript : MonoBehaviour {

    GameObject Stone;
	// Use this for initialization
	private void Awake () {
        Stone = GameObject.FindGameObjectWithTag("Stone");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            Stone.transform.Translate(new Vector2(0.1f, -2f));

        }
    }
}
