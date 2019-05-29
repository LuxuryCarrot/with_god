using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linerenderer : MonoBehaviour {

    LineRenderer Line;
    Vector3 box1Pos, box2Pos;

    private void Start()
    {
        Line = GetComponent<LineRenderer>();
        Line.startWidth = 0.1f;
        Line.endWidth = 0.1f;

        box1Pos = gameObject.GetComponent<Transform>().position;
    }

    private void Update()
    {
        Line.SetPosition(0, box1Pos);
        Line.SetPosition(1, GameObject.Find("box2").GetComponent<Transform>().position);
    }
}
