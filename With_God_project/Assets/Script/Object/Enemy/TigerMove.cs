using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMove : MonoBehaviour
{
    GameObject Player;
    GameObject enemy_check;

    GameObject Tiger;
    GameObject godtree;
    Animator Tiger_ani;

    float speed;
    GameObject FinishPoint;
    bool isTigerOnFinish;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_check = GameObject.FindGameObjectWithTag("Wagon");
        godtree = GameObject.FindGameObjectWithTag("Finish");
        // 태그 재활용..ㅎㅎ

        FinishPoint = GameObject.FindGameObjectWithTag("Tiger_Finish");
        Tiger = GameObject.FindGameObjectWithTag("rope");

        isTigerOnFinish = false;
        Tiger_ani = GetComponent<Animator>();

    }

    void Update()
    {
        speed = 8.0f * Time.deltaTime;

        if (Player.transform.position.x > godtree.transform.position.x + 10 && !isTigerOnFinish)
        {
            transform.position = Vector2.MoveTowards(new Vector2(Tiger.transform.position.x, Tiger.transform.position.y), new Vector2(FinishPoint.transform.position.x, FinishPoint.transform.position.y), speed);
        }
        if (Tiger.transform.position.x == FinishPoint.transform.position.x && Tiger.transform.position.y == FinishPoint.transform.position.y)
        {
            isTigerOnFinish = true;
        }
        if (!isTigerOnFinish)
        {
            Debug.Log("TigerStoped");
            Tiger_ani.SetBool("Moving", true);
        }

        if (isTigerOnFinish)
        {
            Tiger_ani.SetBool("Moving", false);
        }
    }
}
