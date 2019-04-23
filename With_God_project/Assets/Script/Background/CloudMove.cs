using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    public float scrollSize = 0.5f;

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, scrollSize);
        Vector2 offset = new Vector2(x, 0);
        GetComponent<Renderer>().materials[0].SetTextureOffset("_MainTex", offset);
    }
}
