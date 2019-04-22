using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerMainManager {
    
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Horizontal") < 0)
        {
            Debug.Log("BAMM");
            manager.mySpriteRenderer.flipX = true;
            manager.animator.SetBool("isWalking", true);

            transform.Translate(new Vector2(manager.moveDirection.x, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            manager.mySpriteRenderer.flipX = false;
            manager.animator.SetBool("isWalking", true);

            transform.Translate(new Vector2(manager.moveDirection.x, 0));
        }
        else if(Input.GetAxisRaw("Horizontal") == 0)
        {
            manager.animator.SetBool("isWalking", false);
        }
	}
}
