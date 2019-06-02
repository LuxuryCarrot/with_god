using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    GameObject PlayerObj;
    GameObject WagonObj;
    GameObject Ground;

    float PlayerX;
    float PlayerY;
    float WagonX;
    float WagonY;
    float GroundY;

    // Use this for initialization
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        WagonObj = GameObject.FindGameObjectWithTag("Wagon");
        Ground = GameObject.FindGameObjectWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = PlayerObj.transform.position.x;
        PlayerY = PlayerObj.transform.position.y;
        WagonX = WagonObj.transform.position.x;
        WagonY = WagonObj.transform.position.y;
        GroundY = Ground.transform.position.y;
        if (WagonY > GroundY + 1.59)
        {
            transform.Translate(new Vector2(0, -2f * 1.95f * Time.deltaTime));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        bool m = (PlayerX <= (WagonX + 3.25f) && PlayerX >= (WagonX + 3.05f));

        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && m && Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(-1.35f * 1.95f * Time.deltaTime, 0));

        }

        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && m && Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

        }
    }
}