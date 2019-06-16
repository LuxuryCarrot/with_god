using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMove : MonoBehaviour
{
    GameObject Player;
    GameObject enemy_check;

    GameObject Tiger;
    GameObject Tiger_m;

    Animator Tiger_ani;

    float speed;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_check = GameObject.FindGameObjectWithTag("Wagon");
        // 태그 재활용..ㅎㅎ

        Tiger = GameObject.FindGameObjectWithTag("rope");
        Tiger_m = GameObject.FindGameObjectWithTag("rope_b");

        Tiger_ani = GetComponent<Animator>();

        speed = 2.0f;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Player.transform.position.x >= enemy_check.transform.position.x)
        {
            Tiger_ani.SetBool("Moving", true);
            transform.Translate(new Vector2(-1.1f * speed * Time.deltaTime, -0.35f * speed * Time.deltaTime));
        }

        if (Tiger.transform.position.x <= 252)
        {
            Tiger_ani.SetBool("Moving", false);
            transform.Translate(new Vector2(0, 0));
        }
    }
}
