using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour {
    GameObject PlayerObj;
    GameObject WagonObj;
    float PlayerX;
    float PlayerY;
    float WagonX;
    float WagonY;
    
	// Use this for initialization
	void Start () {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        WagonObj = GameObject.FindGameObjectWithTag("Wagon");
	}
	
	// Update is called once per frame
	void Update () {
        PlayerX = PlayerObj.transform.position.x;
        PlayerY = PlayerObj.transform.position.y;
        WagonX = WagonObj.transform.position.x;
        WagonY = WagonObj.transform.position.y;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        bool v = (PlayerX >= (WagonX - 3.25f) && PlayerX <= (WagonX - 3.05f));
        bool m = (PlayerX <= (WagonX + 3.25f) && PlayerX >= (WagonX + 3.05f));
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && v) 
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));
            
        }
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && m)
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(-1.35f * 1.95f * Time.deltaTime, 0));

        }
    }
}
