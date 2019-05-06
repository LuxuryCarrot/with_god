using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSecen_1_Move : MonoBehaviour
{
    GameObject Player;
    //public float Front_Scroll_Speed;
    public float Middle_0_Scroll_Speed;
    public float Middle_1_Scroll_Speed;
    public float Middle_2_Scroll_Speed;
    public float Middle_3_Scroll_Speed;
    //public float Middle_4_Scroll_Speed;
    //public float Middle_5_Scroll_Speed;


    //private GameObject FrontBackGround;
    private GameObject MiddleBackGround0;
    private GameObject MiddleBackGround1;
    private GameObject MiddleBackGround2;
    private GameObject MiddleBackGround3;
    //private GameObject MiddleBackGround4;
    //private GameObject MiddleBackGround5;

    private Vector2 moveDirection = Vector2.zero;
    // Use this for initialization
    private void Awake()
    {
        //FrontBackGround = GameObject.FindGameObjectWithTag("FrontBackGround");
        MiddleBackGround0 = GameObject.FindGameObjectWithTag("MiddleBackGround0");
        MiddleBackGround1 = GameObject.FindGameObjectWithTag("MiddleBackGround1");
        MiddleBackGround2 = GameObject.FindGameObjectWithTag("MiddleBackGround2");
        MiddleBackGround3 = GameObject.FindGameObjectWithTag("MiddleBackGround3");
        Player = GameObject.FindGameObjectWithTag("Player");
        //MiddleBackGround4 = GameObject.FindGameObjectWithTag("MiddleBackGround4");
        //MiddleBackGround5 = GameObject.FindGameObjectWithTag("MiddleBackGround5");

        //Front_Scroll_Speed = 1.1f;
        Middle_0_Scroll_Speed = 0.9f;
        Middle_1_Scroll_Speed = 0.55f;
        Middle_2_Scroll_Speed = 0.5f;
        Middle_3_Scroll_Speed = 0.08f;
        //Middle_4_Scroll_Speed = 0.3f;
        //Middle_5_Scroll_Speed = 0.1f;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0);


        if (Player.transform.position.x > -2 && Player.transform.position.y > -4)
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //FrontBackGround.transform.Translate(new Vector2(-moveDirection.x * Front_Scroll_Speed, 0));
                //MiddleBackGround0.transform.Translate(new Vector2(-moveDirection.x * Middle_0_Scroll_Speed, 0));
                MiddleBackGround1.transform.Translate(new Vector2(-moveDirection.x * Middle_1_Scroll_Speed, 0));
                MiddleBackGround2.transform.Translate(new Vector2(-moveDirection.x * Middle_2_Scroll_Speed, 0));
                MiddleBackGround3.transform.Translate(new Vector2(-moveDirection.x * Middle_3_Scroll_Speed, 0));
                //MiddleBackGround4.transform.Translate(new Vector2(-moveDirection.x * Middle_4_Scroll_Speed, 0));
                //MiddleBackGround5.transform.Translate(new Vector2(-moveDirection.x * Middle_5_Scroll_Speed, 0));
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //FrontBackGround.transform.Translate(new Vector2(-moveDirection.x * Front_Scroll_Speed, 0));
                //MiddleBackGround0.transform.Translate(new Vector2(-moveDirection.x * Middle_0_Scroll_Speed, 0));
                MiddleBackGround1.transform.Translate(new Vector2(-moveDirection.x * Middle_1_Scroll_Speed, 0));
                MiddleBackGround2.transform.Translate(new Vector2(-moveDirection.x * Middle_2_Scroll_Speed, 0));
                MiddleBackGround3.transform.Translate(new Vector2(-moveDirection.x * Middle_3_Scroll_Speed, 0));
                //MiddleBackGround4.transform.Translate(new Vector2(-moveDirection.x * Middle_4_Scroll_Speed, 0));
                //MiddleBackGround5.transform.Translate(new Vector2(-moveDirection.x * Middle_5_Scroll_Speed, 0));
            }
        }


    }
}