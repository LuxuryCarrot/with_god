using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedForce = 5.0f;
    public Vector2 jumpVector;
    private Rigidbody2D rigi;
    // Use this for initialization
    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigi.velocity = new Vector2(-speedForce, rigi.velocity.y);
            transform.localScale = new Vector3(-0.2f, 0.2f, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigi.velocity = new Vector2(speedForce, rigi.velocity.y);
            transform.localScale = new Vector3(0.2f, 0.2f, 1);
        }
        else
        {
            rigi.velocity = new Vector2(0, rigi.velocity.y);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rigi.AddForce(jumpVector, ForceMode2D.Force);
        }

    }
}
