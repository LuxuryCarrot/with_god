using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    GameObject PlayerObj;
    GameObject WagonObj;
    //GameObject Ground;
    GameObject Rope_b; // 박스랑 연결된 로프
    GameObject Rope_m; // 가운데 로프
    GameObject Rope_w; // 수레랑 연결된 로프

    GameObject box;

    float PlayerX;
    float PlayerY;
    float WagonX;
    float WagonY;

    float Rope_bX;
    float Rope_bY;
    float Rope_mX;
    float Rope_mY;
    float Rope_wX;
    float Rope_wY;

    //float GroundY;

    // Use this for initialization
    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        WagonObj = GameObject.FindGameObjectWithTag("Wagon");
        //Ground = GameObject.FindGameObjectWithTag("Ground");

        Rope_b = GameObject.FindGameObjectWithTag("rope_b");
        Rope_m = GameObject.FindGameObjectWithTag("rope");
        Rope_w = GameObject.FindGameObjectWithTag("rope_w");

        box = GameObject.FindGameObjectWithTag("Box");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = PlayerObj.transform.position.x;
        PlayerY = PlayerObj.transform.position.y;
        WagonX = WagonObj.transform.position.x;
        WagonY = WagonObj.transform.position.y;

        Rope_bX = Rope_b.transform.position.x;
        Rope_bY = Rope_b.transform.position.y;
        Rope_mX = Rope_m.transform.position.x;
        Rope_mY = Rope_m.transform.position.y;
        Rope_wX = Rope_w.transform.position.x;
        Rope_wY = Rope_w.transform.position.y;

        //GroundY = Ground.transform.position.y;

        //if (WagonY > GroundY + 1.59)
        //{
        //    transform.Translate(new Vector2(0, -2f * 1.95f * Time.deltaTime));
        //}

        bool r = (PlayerX <= (WagonX + 3f) && PlayerX >= (WagonX + 2.5f)); // 수레 오른쪽에 있을 때
        bool l = (PlayerX <= (WagonX - 2f) && PlayerX >= (WagonX - 2.5f)); // 수레 왼쪽에 있을 때

        if (Input.GetKey(KeyCode.LeftControl) && l && Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));

            Rope_w.transform.Translate(new Vector2(0.05f, 0));
            Rope_w.transform.Rotate(new Vector3(0, 0, 0.2f));
            Rope_b.transform.Translate(new Vector2(0, 0.03f));
            box.transform.Translate(new Vector2(0, 0.03f));
        }

        if (Input.GetKey(KeyCode.LeftControl) && r && Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));

            Rope_b.transform.Translate(new Vector2(0, 0.03f));
            box.transform.Translate(new Vector2(0, 0.03f));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("ground!");
        }
    }
}