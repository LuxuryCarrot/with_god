using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMove : MonoBehaviour {

    GameObject box;
    GameObject player;

    float boxX;
    float playerX;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        box = GameObject.FindGameObjectWithTag("Box");
    }

    void Start () {
    }
	
	void Update () {

        playerX = player.transform.position.x;
        boxX = box.transform.position.x;

        bool r = (playerX <= (boxX + 3f) && playerX >= (boxX + 2.5f));
        bool l = (playerX <= (boxX - 2f) && playerX >= (boxX - 2.5f));

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightArrow) && l && r)
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));
        }

    }
}
