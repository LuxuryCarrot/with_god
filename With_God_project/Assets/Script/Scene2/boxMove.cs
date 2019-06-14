using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxMove : MonoBehaviour
{

    GameObject box;
    GameObject player;

    float boxX;
    float boxY;
    float playerX;
    float playerY;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        box = GameObject.FindGameObjectWithTag("Box");
    }

    void Start () {
    }
	
	void Update () {

        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        boxX = box.transform.position.x;
        boxY = box.transform.position.y;

        bool r = (playerX <= (boxX + 3f) && playerX >= (boxX + 2.5f));
        bool l = (playerX <= (boxX - 2f) && playerX >= (boxX - 2.5f));

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightArrow) && l && r)
        {
            Debug.Log("attached");
            transform.Translate(new Vector2(1.35f * 1.95f * Time.deltaTime, 0));
        }

        // 수정ㄹ해,,,
        //if (boxY <= (playerY + 1.0f) && boxX <= (playerX + 0.3f) && boxY > -0.2f)
        //{
        //    SceneManager.LoadScene("StartScene");
        //}

    }
}
