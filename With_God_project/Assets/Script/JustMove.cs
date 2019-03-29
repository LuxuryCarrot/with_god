using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustMove : MonoBehaviour {

    int moveSpeed;

	// Use this for initialization
	void Awake () {
        moveSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
        float xMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));
    }
}
