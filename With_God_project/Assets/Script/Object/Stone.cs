using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    GameObject PlayerObj;
    GameObject StoneObj;

    float PlayerForce = 0.0f;
	// Use this for initialization
	void Start () {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        StoneObj = GameObject.FindGameObjectWithTag("Stone");
	}
	

	// Update is called once per frame
	void Update () {
   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
        {
            PlayerForce -= 0.1f;
            Debug.Log("Down");
        }
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            PlayerForce += 0.1f;
            Debug.Log("Up");
        }
        if (other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.Translate(new Vector2(0.1f * 2.5f * Time.deltaTime, PlayerForce));
        }
    }
}
