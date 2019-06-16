using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {

    private void Start()
    {
        Invoke("SceneStart", 3);
    }
    void SceneStart()
    {
        SceneManager.LoadScene("Scene1");
    }
}
