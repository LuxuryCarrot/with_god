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

    bool StoneTowerPosCheck;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");
        EndPos = GameObject.FindGameObjectWithTag("EndPos");
    }
    private void Update()
    {
        PlayerPosX = Player.transform.position.x;
        PlayerPosY = Player.transform.position.y;
        StoneTowerPosX = StoneTower.transform.position.x;
        StoneTowerPosY = StoneTower.transform.position.y;

        StoneTowerPosCheck = (PlayerPosX > StoneTowerPosX - 0.75f && PlayerPosX < StoneTowerPosX + 0.65f
                             && PlayerPosY > StoneTowerPosY - 0.9f && PlayerPosY < StoneTowerPosY + 0.9f);

        if (StoneTowerPosCheck && Input.GetKeyUp(KeyCode.LeftControl) /*&& StonePosX < EndPosX && StonePosY < EndPosY*/)
        {
            Debug.Log("asdkjo");
            float step = 0.2f * Time.deltaTime;

            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(EndPos.transform.position.x, EndPos.transform.position.y ), step);
        }
    }
     
}
