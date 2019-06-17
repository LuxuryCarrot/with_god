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
    Vector2 FinishPoint;
    bool isTigerOnFinish;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_check = GameObject.FindGameObjectWithTag("Wagon");
        godtree = GameObject.FindGameObjectWithTag("Finish");
        // 태그 재활용..ㅎㅎ

        FinishPoint = new Vector2(247, -4);
        Tiger = GameObject.FindGameObjectWithTag("rope");

        isTigerOnFinish = false;
        Tiger_ani = GetComponent<Animator>();

    }

    void Update()
    {
        speed = 8.0f * Time.deltaTime;

        if (Player.transform.position.x > godtree.transform.position.x + 10 && !isTigerOnFinish)
        {
            transform.position = Vector2.MoveTowards(new Vector2(Tiger.transform.position.x, Tiger.transform.position.y), new Vector2(FinishPoint.x, FinishPoint.y), speed);
        }
        if (Tiger.transform.position.x == 247 && Tiger.transform.position.y == -4)
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

        if (Player.transform.position.x >= 234)
        {
            Tiger_ani.SetBool("Attack", true);
            transform.Translate(-4f * Time.deltaTime, 0, 0);
        }

        if (transform.position.x <= 236.9f)
        {
            Tiger.SetActive(false);
        }
    }
}
