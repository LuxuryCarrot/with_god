using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternMove : MonoBehaviour {

    GameObject Stalactite_s;
    GameObject Player;
    GameObject Lantern;
    GameObject GroundCheck;

    //public bool isGrounded;
	// Use this for initialization
	void Awake () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Stalactite_s = GameObject.FindGameObjectWithTag("Stalactite_s");
        Lantern = GameObject.FindGameObjectWithTag("Lantern");
        GroundCheck = GameObject.FindGameObjectWithTag("GroundCheck");

        //isGrounded = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.position.x > Stalactite_s.transform.position.x && Lantern.transform.position.x < Player.transform.position.x + 3)
        {
            Lantern.GetComponent<SpriteRenderer>().enabled = true;
            Lantern.transform.Translate(new Vector2(0.03f, 0));
        }
        //if (Lantern.transform.position.y < GroundCheck.transform.position.y + 1f)
        //{
        //    Lantern.transform.Translate(new Vector2(0, 0.05f));
        //}
        //if (Lantern.transform.position.y > GroundCheck.transform.position.y + 1.2f)
        //{
        //    Lantern.transform.Translate(new Vector2(0, -0.05f));
        //}
        //if (!isGrounded)
        //{
        //    GroundCheck.transform.Translate(new Vector2(0, -0.01f));
        //}
        //if (isGrounded)
        //{
        //    GroundCheck.transform.Translate(new Vector2(0, 0.01f));
        //    isGrounded = false;
        //}
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        Debug.Log("땅입니다. ");
    //        isGrounded = true;
    //    }
    //}
    
}
