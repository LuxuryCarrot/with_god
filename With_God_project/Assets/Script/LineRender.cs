using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineRender : MonoBehaviour
{
    LineRenderer lr;
    Vector2 PlayerPos, EndPos;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.startWidth = .05f;
        lr.endWidth = .05f;

        PlayerPos = gameObject.GetComponent<Transform>().position;



    }
    private void Update()
    {
        
        lr.SetPosition(0, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
        lr.SetPosition(1, GameObject.FindGameObjectWithTag("EndPos").GetComponent<Transform>().position);
    }

}