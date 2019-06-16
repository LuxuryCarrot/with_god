using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMaker_2 : MonoBehaviour {

    GameObject centi;
    GameObject Player;
    GameObject Stalactite;

    SpriteRenderer centiSprite;

    private float centiSpeed;

    public bool isCentiSlow;
    public bool isCentiFast;
    public bool isEventStart;
   
    // Use this for initialization
    private void Awake()
    {
        centi = GameObject.FindGameObjectWithTag("centi");
        Player = GameObject.FindGameObjectWithTag("Player");
        Stalactite = GameObject.FindGameObjectWithTag("stalactite_event_1");

        centiSprite = centi.GetComponent<SpriteRenderer>();
        isCentiFast = false;
        isCentiSlow = false;
        isEventStart = false;
    }
    private void Start()
    {
        Invoke("fastSpeed", 2);
    }

    // Update is called once per frame
    void Update() {
        if (isEventStart)
        {
            centi.transform.Translate(new Vector2(centiSpeed, 0));

        }
    }
    void slowSpeed()
    {
        Debug.Log("1초");

        centiSpeed = 0.05f;
        if (centi.transform.position.x < 244)
        {
            if (isEventStart)
            {
                if (centi.transform.position.x + 9.5 > Player.transform.position.x && centi.transform.position.y + 20 > Player.transform.position.y && centi.transform.position.x - 9.5 < Player.transform.position.x && centi.transform.position.y - 20 < Player.transform.position.y)
                {
                    SceneManager.LoadScene("StartScene");
                }
            }
            Invoke("fastSpeed", 2);
        }
        if (centi.transform.position.x > 244)
        {
            centiSpeed = -0.0001f;
        }
    }
    void fastSpeed()
    {
        Debug.Log("2초");

        centiSpeed = 0.10f;
        if (centi.transform.position.x < 244)
        {
            if (isEventStart)
            {
                Stalactite.transform.position = new Vector2(Player.transform.position.x + 6, Player.transform.position.y + 10);
                Stalactite.transform.Translate(new Vector2(0, 0.25f));
                if (centi.transform.position.x + 9.5 > Player.transform.position.x && centi.transform.position.y + 20 > Player.transform.position.y && centi.transform.position.x - 9.5 < Player.transform.position.x && centi.transform.position.y - 20 < Player.transform.position.y)
                {
                    SceneManager.LoadScene("StartScene");
                }
            }
            Invoke("slowSpeed", 1);
        }
        if (centi.transform.position.x > 244)
        {
            centiSpeed = -0.0001f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            centi.transform.position = new Vector2(Player.transform.position.x - 20, Player.transform.position.y + 3);
            centiSprite.flipX = false;
            isEventStart = true;
            isCentiSlow = true;
        }
        

    }
}
