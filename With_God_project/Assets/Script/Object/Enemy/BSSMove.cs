using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSSMove : MonoBehaviour {

    GameObject BSS;
    GameObject Player;
    GameObject Tiger;
    GameObject enemy_check;
    Animator ani;

    float speed;
    Vector2 FinishPoint;

    bool isBSSOnFinish;

    private void Awake()
    {
        BSS = GameObject.FindGameObjectWithTag("rope_b");
        Player = GameObject.FindGameObjectWithTag("Player");
        Tiger = GameObject.FindGameObjectWithTag("rope");
        // 태그 재활용..ㅎㅎ

        ani = GetComponent<Animator>();

        FinishPoint = new Vector2(237, -3.5f);

        isBSSOnFinish = false;

        BSS.SetActive(false);

        //ani.SetBool("Walking", false);
        //ani.SetBool("Attack", false);
    }

    void Start () {
		
	}
	
	void Update () {

        speed = 5.0f * Time.deltaTime;

        if (Player.transform.position.x >= 228 && !isBSSOnFinish)
        {
            BSS.SetActive(true);
            ani.SetBool("Walking", true);
            transform.position = Vector2.MoveTowards(new Vector2(BSS.transform.position.x, BSS.transform.position.y), new Vector2(FinishPoint.x, FinishPoint.y), speed);
        }

        if (BSS.transform.position.x == 237 && BSS.transform.position.y == -3.5f)
        {
            isBSSOnFinish = true;
        }
        if (!isBSSOnFinish)
        {
            ani.SetBool("Moving", true);
        }
        if(isBSSOnFinish)
        {
            ani.SetBool("Moving", false);
        }

	}
}
