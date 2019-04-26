using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SightCheck : MonoBehaviour {

    public float distance = 5.0f;
    public LayerMask PlayerMask;
    GameObject Player;
    

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(3, 4), PlayerMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Player")
        {
            Player.SetActive(false);
            SceneManager.LoadScene("StartScene");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(3, 4));
    }
}
