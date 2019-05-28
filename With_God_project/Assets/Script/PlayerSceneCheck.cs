using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSceneCheck : MonoBehaviour {

    GameObject Player;
    // Use this for initialization
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}
