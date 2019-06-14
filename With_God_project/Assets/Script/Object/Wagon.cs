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
    //float PlayerY;
    float WagonX;
    //float WagonY;

    float speed = 0.9f;

    public Animator ani;

    //float GroundY;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

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
        //PlayerY = PlayerObj.transform.position.y;
        WagonX = WagonObj.transform.position.x;
        //WagonY = WagonObj.transform.position.y;

        //GroundY = Ground.transform.position.y;

        //if (WagonY > GroundY + 1.59)
        //{
        //    transform.Translate(new Vector2(0, -2f * 1.95f * Time.deltaTime));
        //}

        bool r = (PlayerX <= (WagonX + 3f) && PlayerX >= (WagonX + 2.5f)); // 수레 오른쪽에 있을 때
        bool l = (PlayerX <= (WagonX - 2f) && PlayerX >= (WagonX - 2.5f)); // 수레 왼쪽에 있을 때

        // 캐릭터가 수레의 왼쪽에 있을 때
        if (Input.GetKey(KeyCode.LeftControl) && l && Input.GetKey(KeyCode.RightArrow) && (WagonX <= 147.7f))
        {
            //ani.SetBool("run", true);


            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));

            Rope_w.transform.Translate(0.7f * Time.deltaTime, -speed * Time.deltaTime, 0);
            Rope_w.transform.Rotate(0, 0, 2.2f * Time.deltaTime);

            Rope_m.transform.Translate(-0.5f * Time.deltaTime, 2.0f * Time.deltaTime, 0);
            Rope_m.transform.Rotate(0, 0, -1.3f * Time.deltaTime);


            Rope_b.transform.Translate(new Vector2(0, 0.03f));

            box.transform.Translate(new Vector2(0, 0.03f));
        }

        // 캐릭터가 수레의 오른쪽에 있을 때
        if (Input.GetKey(KeyCode.LeftControl) && r && Input.GetKey(KeyCode.RightArrow) && (WagonX <= 147.7f))
        {
            //ani.SetBool("run", true);

            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));

            Rope_w.transform.Translate(0.7f * Time.deltaTime, -speed * Time.deltaTime, 0);
            Rope_w.transform.Rotate(0, 0, 2.2f * Time.deltaTime);

            Rope_m.transform.Translate(-0.5f * Time.deltaTime, 2.0f * Time.deltaTime, 0);
            Rope_m.transform.Rotate(0, 0, -1.3f * Time.deltaTime);


            Rope_b.transform.Translate(new Vector2(0, 0.03f));

            box.transform.Translate(new Vector2(0, 0.03f));
        }

        if(WagonX >= 147.7f && box.transform.position.y > -0.25f)
        {
            box.transform.Translate(new Vector2(0, -0.2f));
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