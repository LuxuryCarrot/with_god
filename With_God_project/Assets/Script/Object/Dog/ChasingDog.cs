using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasingDog : MonoBehaviour {
    GameObject Player;
    GameObject DogCheck;
    public float Speed = 5.145f;
    private Animator animator;
    public SpriteRenderer mySpriteRenderer;

    // Use this for initialization
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        DogCheck = GameObject.FindGameObjectWithTag("DogCheck");
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(DogCheck.transform.position.x < Player.transform.position.x && Player.transform.position.x < 180)
        {
            transform.Translate(new Vector2(1 * Speed * Time.deltaTime, 0));

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
