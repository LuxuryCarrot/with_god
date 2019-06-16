using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaker_1 : MonoBehaviour {

    GameObject centi;
    GameObject Player;
    GameObject stalactite_event_1;

    SpriteRenderer CentiSprite;
    bool isCentiMove;
    bool isEvent1Start;
	// Use this for initialization
	void Awake () {
        centi = GameObject.FindGameObjectWithTag("centi");
        Player = GameObject.FindGameObjectWithTag("Player");
        stalactite_event_1 = GameObject.FindGameObjectWithTag("stalactite_event_1");
        CentiSprite = centi.GetComponent<SpriteRenderer>();
        isCentiMove = false;
        isEvent1Start = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isCentiMove)
        {
            centi.transform.Translate(new Vector2(-0.4f, 0));
        }
        if (isEvent1Start)
        {
            stalactite_event_1.transform.Translate(new Vector2(0, -0.2f));
        }
        if (centi.transform.position.x < Player.transform.position.x - 50)
        {
            isCentiMove = false;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            centi.transform.position = new Vector2(Player.transform.position.x + 50, Player.transform.position.y + 9.5f);
            stalactite_event_1.transform.position = new Vector2(transform.position.x-1, transform.position.y + 10);
            CentiSprite.flipX = true;
            isCentiMove = true;
            isEvent1Start = true;
        }
    }
}
