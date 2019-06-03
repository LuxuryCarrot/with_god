using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    GameObject Player;
    GameObject StoneTower;
    GameObject EndPos;

    Rigidbody2D _rb;


    private float EndPosX, EndPosY;
    private float PlayerPosX, PlayerPosY;
    private float StoneTowerPosX, StoneTowerPosY;

    private Vector2 StoneMove;

    bool StoneTowerPosCheck;
    bool go = false;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StoneTower = GameObject.FindGameObjectWithTag("StoneTower");
        EndPos = GameObject.FindGameObjectWithTag("EndPos");
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    private void Update()
    {
        float step = 8f * Time.deltaTime;

        StoneMove = new Vector2(EndPos.transform.position.x, EndPos.transform.position.y);
        PlayerPosX = Player.transform.position.x;
        PlayerPosY = Player.transform.position.y;
        StoneTowerPosX = StoneTower.transform.position.x;
        StoneTowerPosY = StoneTower.transform.position.y;

        StoneTowerPosCheck = (PlayerPosX > StoneTowerPosX - 0.75f && PlayerPosX < StoneTowerPosX + 0.65f
                             && PlayerPosY > StoneTowerPosY - 0.9f && PlayerPosY < StoneTowerPosY + 0.9f);

        if (StoneTowerPosCheck && Input.GetKey(KeyCode.LeftControl) /*&& StonePosX < EndPosX && StonePosY < EndPosY*/)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            _rb.isKinematic = true;

        }
        if (StoneTowerPosCheck && Input.GetKeyUp(KeyCode.LeftControl) /*&& StonePosX < EndPosX && StonePosY < EndPosY*/)
        {

            Debug.Log("asdkjo");

            go = true;

        }
        if (go == true)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(StoneMove.x, StoneMove.y), step);
            if (transform.position == EndPos.transform.position)
            {
                GetComponent<CircleCollider2D>().enabled = true;
                _rb.isKinematic = false;
                //transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y-10);
                EndPos.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
                go = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            GetComponent<CircleCollider2D>().enabled = false;
            _rb.isKinematic = true;
        }
    }

}
