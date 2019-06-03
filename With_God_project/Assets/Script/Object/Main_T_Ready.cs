using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_T_Ready : MonoBehaviour
{
    GameObject Stone;
    GameObject Player;
    GameObject StoneTower;
    GameObject EndPos;
    GameObject Position;
    private float EndPosX, EndPosY;
    private float PlayerPosX, PlayerPosY;
    private float StoneTowerPosX, StoneTowerPosY;
    public float Xpos, Ypos;
    bool enter = true;
    bool StoneTowerPosCheck;
    // Use this for initialization
    void Start()
    {
        Stone = GameObject.FindGameObjectWithTag("Stone");
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");

        Position = GameObject.FindGameObjectWithTag("PosCheck");
        EndPos = GameObject.FindGameObjectWithTag("EndPos");

        EndPosX = Player.transform.position.x;
        EndPosY = Player.transform.position.y;

        
    }
    private void Update()
    {
        PlayerPosX = Player.transform.position.x;
        PlayerPosY = Player.transform.position.y;
        StoneTowerPosX = StoneTower.transform.position.x;
        StoneTowerPosY = StoneTower.transform.position.y;

        StoneTowerPosCheck = (PlayerPosX > StoneTowerPosX - 0.75f && PlayerPosX < StoneTowerPosX + 0.65f
                              &&PlayerPosY > StoneTowerPosY - 0.9f && PlayerPosY < StoneTowerPosY + 0.9f);

        if (StoneTowerPosCheck && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Stone.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 0.000001f);
        }
        if (StoneTowerPosCheck && Input.GetKey(KeyCode.LeftControl) && EndPosX < 73f)
        {
            enter = false;
            Debug.Log("in");
            EndPosX += 0.1f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }

        //Position.transform.position = new Vector2(StoneTower.transform.position.x - Xpos, StoneTower.transform.position.y + Ypos); //스프라이트 위치값찾기

        if (enter == true)
        {
            EndPosX = Player.transform.position.x;
            EndPosY = Player.transform.position.y;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }


    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.LeftControl) && (Player.transform.position != Stone.transform.position))
        //{
        //    Stone.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 0.000001f);
        //}
        //if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftControl) && EndPosX < 73f)
        //{
        //    enter = false;
        //    Debug.Log("in");
        //    EndPosX += 0.1f;
        //    EndPos.transform.position = new Vector2(EndPosX, EndPosY);

          
        //}
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow) && EndPosY < 2.5f)
        {
            enter = false;
            Debug.Log("in");
            EndPosY += 0.1f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.DownArrow) && EndPosY > -2.3f)
        {
            enter = false;
            Debug.Log("in");
            EndPosY -= 0.1f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }
    }
}
