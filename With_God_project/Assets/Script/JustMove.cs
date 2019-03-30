using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMove : MonoBehaviour {

    public float moveSpeed;
    public float xMove;
    Animator animator;
    // Use this for initialization
    void Awake () {
        moveSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
        
        xMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("leftarrow");

            this.transform.Translate(new Vector3(xMove, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(xMove, 0, 0));
        }
        
    }
}
