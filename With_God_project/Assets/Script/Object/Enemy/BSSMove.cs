using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSSMove : MonoBehaviour {

    GameObject BSS;
    GameObject Player;
    GameObject enemy_check;
    Animator ani;

    float speed;
    

    private void Awake()
    {
        BSS = GameObject.FindGameObjectWithTag("rope_b");
        Player = GameObject.FindGameObjectWithTag("Player");
        enemy_check = GameObject.FindGameObjectWithTag("rope");
        // 태그 재활용..ㅎㅎ

        ani = GetComponent<Animator>();

        speed = 5.0f;

        //ani.SetBool("Walking", false);
        //ani.SetBool("Attack", false);
    }

    void Start () {
		
	}
	
	void Update () {

        if (Player.transform.position.x < enemy_check.transform.position.x)
        {
            BSS.SetActive(false);
        }

        if(Player.transform.position.x > enemy_check.transform.position.x && Player.transform.position.x > 200)
        {
            BSS.SetActive(true);
            //ani.SetBool("Walking", true);

            transform.Translate(new Vector2(1 * speed * Time.deltaTime, 0));
        }

        //if ((Player.transform.position.x - transform.position.x) <= 6)
        //{
        //    ani.SetBool("Walking", false);
        //}
	}
}
