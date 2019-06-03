using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour {

    GameObject Start;
    GameObject End;



    Vector2 CurrPos;
    Vector2 EndPos;            

    // Use this for initialization
    private void Awake()
    {
        Start = GameObject.FindGameObjectWithTag("Start");
        End = GameObject.FindGameObjectWithTag("End");
        CurrPos = Start.transform.position;
    }

    // Update is called once per frame
    void Update () {
        
        EndPos = new Vector2(0.0f, 0.0f);
        Debug.Log(CurrPos);
        Debug.Log(EndPos);
        float step = 0.1f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x , transform.position.y), new Vector2(EndPos.x, EndPos.y), step);
       
	}
}
