using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellScript : MonoBehaviour
{
    GameObject Stone;
    GameObject door_o;
    GameObject door_c;
    // Use this for initialization
    private void Awake()
    {
        Stone = GameObject.FindGameObjectWithTag("Stone");
        door_c = GameObject.FindGameObjectWithTag("door_c");
        door_o = GameObject.FindGameObjectWithTag("door_o");

        door_o.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            door_c.GetComponent<SpriteRenderer>().enabled = false;
            door_c.GetComponent<BoxCollider2D>().enabled = false;
            door_o.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
