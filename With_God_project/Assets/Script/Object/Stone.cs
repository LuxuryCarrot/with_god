using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {
    GameObject Player;
    GameObject StoneTower;
    GameObject EndPos;

    private float EndPosX, EndPosY;
    private float PlayerPosX, PlayerPosY;
    private float StoneTowerPosX, StoneTowerPosY;

    private Vector2 StoneMove;

    bool StoneTowerPosCheck;
    bool go = false;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");
        EndPos = GameObject.FindGameObjectWithTag("EndPos");
    }
    private void Update()
    {
        float step = 8f * Time.deltaTime;

        StoneMove = new Vector2( EndPos.transform.position.x, EndPos.transform.position.y);
        PlayerPosX = Player.transform.position.x;
        PlayerPosY = Player.transform.position.y;
        StoneTowerPosX = StoneTower.transform.position.x;
        StoneTowerPosY = StoneTower.transform.position.y;

        StoneTowerPosCheck = (PlayerPosX > StoneTowerPosX - 0.75f && PlayerPosX < StoneTowerPosX + 0.65f
                             && PlayerPosY > StoneTowerPosY - 0.9f && PlayerPosY < StoneTowerPosY + 0.9f);

        if (StoneTowerPosCheck && Input.GetKeyUp(KeyCode.LeftControl) /*&& StonePosX < EndPosX && StonePosY < EndPosY*/)
        {
            Debug.Log("asdkjo");

            go = true;

        }
        if(go == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(StoneMove.x, StoneMove.y), step);
            if (transform.position == EndPos.transform.position)
            {
                transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y-10);
                EndPos.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
                go = false;
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (go == true)
    //    {
    //        if (transform.position == EndPos.transform.position && collision.gameObject.tag != "Bell")
    //        {
    //            transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y - 10);
    //            //EndPos.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    //            go = false;
    //        }
    //    }
        
    //}

}
