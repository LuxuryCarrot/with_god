using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSMState : MonoBehaviour {

    public PlayerFSMManager manager;

    private void Awake()
    {
        manager = GetComponent<PlayerFSMManager>();
    }
}
