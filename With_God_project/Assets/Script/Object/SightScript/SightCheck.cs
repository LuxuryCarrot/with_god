using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SightCheck : MonoBehaviour {

    GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
