using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_T_Ready : MonoBehaviour {
    GameObject Stone;
    GameObject Player;
    GameObject StoneTower;

	// Use this for initialization
	void Start () {
        Stone = GameObject.FindGameObjectWithTag("Stone");
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");
	}
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl) && (Player.transform.position != Stone.transform.position))
        {
            Stone.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 0.000001f);
        }
    }
}
