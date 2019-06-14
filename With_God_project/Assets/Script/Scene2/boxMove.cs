using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxMove : MonoBehaviour
{
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }
    	
	void Update () {
        if (transform.position.y  > 9f)
        {
            Debug.Log("y > 11  ");
            _rb.isKinematic = false;
        }
    }
}
