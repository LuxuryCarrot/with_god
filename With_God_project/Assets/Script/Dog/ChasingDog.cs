﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingDog : MonoBehaviour {
    GameObject Player;
    GameObject DogCheck;
    private float Speed;
    private Animator animator;
    public SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        Speed = 5.27f;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(DogCheck.transform.position.x < Player.transform.position.x && Player.transform.position.x < 193)
        {
            transform.Translate(new Vector2(1 * Speed * Time.deltaTime, 0));

        }
        if(Player.transform.position.x >= 193)
        {
            transform.Translate(new Vector2(-1 * Speed * Time.deltaTime, 0));
            mySpriteRenderer.flipX = true;
        }
      
        
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Player.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }
    }

}