using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMaker_2 : MonoBehaviour {

    GameObject centi;
    GameObject Player;

    SpriteRenderer centiSprite;

    private float centiSpeed;

    public bool isCentiSlow;
    public bool isCentiFast;
    // Use this for initialization
    private void Awake()
    {
        centi = GameObject.FindGameObjectWithTag("centi");
        Player = GameObject.FindGameObjectWithTag("Player");
        centiSprite = centi.GetComponent<SpriteRenderer>();
        isCentiFast = false;
        isCentiSlow = false;
    }

    // Update is called once per frame
    void Update() {

        if (isCentiSlow)
        {
            centi.transform.Translate(new Vector2(0.05f, 0));

            isCentiSlow = false;
            isCentiFast = true;
            TwoSeconds();
            Debug.Log("2초");
        }
        if (isCentiFast)
        {
            centi.transform.Translate(new Vector2(1f, 0));
            isCentiFast = false;
            isCentiSlow = true;
            OneSeconds();
            Debug.Log("1초");
        }
    }
    IEnumerator TwoSeconds()
    {
        yield return new WaitForSeconds(2);
    }
    IEnumerator OneSeconds()
    {
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            centi.transform.position = new Vector2(Player.transform.position.x - 20, Player.transform.position.y + 4);
            centiSprite.flipX = false;
            isCentiSlow = true;
        }

    }
}
