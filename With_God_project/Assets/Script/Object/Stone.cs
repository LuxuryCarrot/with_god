using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    GameObject PlayerObj;
    GameObject StoneObj;
    GameObject EndPos;

    Vector2 CurrPosition;
    Vector2 EndPosition;

    float speed = 3f;
	// Use this for initialization
	void Start () {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        StoneObj = GameObject.FindGameObjectWithTag("Stone");
        EndPos = GameObject.FindGameObjectWithTag("EndPos");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.LeftControl))
        {
            Debug.Log("up")
            CurrPosition = transform.position;
            EndPosition = new Vector2(EndPos.transform.position.x, EndPos.transform.position.y);
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(CurrPosition, EndPosition, step);

        }
    }
    
}
