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
    private float StonePosX, StonePosY;
    private Vector2 CurrPosition, EndPosition;

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
        StonePosX = Stone.transform.position.x;
        StonePosY = Stone.transform.position.y;

        StoneTowerPosCheck = (PlayerPosX > StoneTowerPosX - 0.75f && PlayerPosX < StoneTowerPosX + 0.65f
                              &&PlayerPosY > StoneTowerPosY - 0.9f && PlayerPosY < StoneTowerPosY + 0.9f);

        if (StoneTowerPosCheck && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Stone.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
            Debug.Log("in");

        }
        if (StoneTowerPosCheck && Input.GetKey(KeyCode.LeftControl) && EndPosX < 73f)
        {
            enter = false;
            EndPosX += 0.06f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }
        if (StoneTowerPosCheck && Input.GetKey(KeyCode.UpArrow) && EndPosY < 2.5f)
        {
            enter = false;
            EndPosY += 0.06f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }
        if (StoneTowerPosCheck && Input.GetKey(KeyCode.DownArrow) && EndPosY > -2.3f)
        {
            enter = false;
            EndPosY -= 0.06f;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }

    
        if (StoneTowerPosCheck == false)
        {
            enter = true;
        }

        //Position.transform.position = new Vector2(StoneTower.transform.position.x - Xpos, StoneTower.transform.position.y + Ypos); //스프라이트 위치값찾기

        if (enter == true)
        {
            EndPosX = Player.transform.position.x;
            EndPosY = Player.transform.position.y;
            EndPos.transform.position = new Vector2(EndPosX, EndPosY);
        }
        if (Stone.transform.position == EndPos.transform.position)
        {
            enter = true;
        }
    }
}
