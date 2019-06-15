using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMove : MonoBehaviour
{
    GameObject Player;
    GameObject enemy_check;
    Animator Tiger_ani;

    float speed;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_check = GameObject.FindGameObjectWithTag("rope");
        // 태그 재활용..ㅎㅎ

        Tiger_ani = GetComponent<Animator>();

        speed = 5.0f;
    }

    void Start()
    {
        
    }

    void Update()
    {

        if (Player.transform.position.x >= enemy_check.transform.position.x)
        {

        }
    }
}
