using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

    private Rigidbody2D rigi;
    public float distance = 1.0f;
    public LayerMask boxMask;
    GameObject box;

    // Use this for initialization
    private void Awake()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && Input.GetKey(KeyCode.E))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
