using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    RUN,
    JUMP,
    DEAD
}
public class PlayerFSMManager : MonoBehaviour {

    public PlayerState currentState;
    public PlayerState startState;
    public CharacterController cc;
    public float moveSpeed;
    public float fallSpeed;
    public float h;

    public Rigidbody rigid;

    Vector3 movement;
    bool isJumping;

    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();

    private void Awake()
    {

        cc = GetComponent<CharacterController>();

        states.Add(PlayerState.IDLE, GetComponent<PlayerIDLE>());
        states.Add(PlayerState.RUN, GetComponent<PlayerRUN>());
    }
    // Use this for initialization
    private void Start() {

        rigid = gameObject.GetComponent<Rigidbody>();

        SetState(startState);

    }

    public void SetState(PlayerState newState)
    {
        foreach(PlayerFSMState fsm in states.Values)
        {
            fsm.enabled = false;
        }

        states[newState].enabled = true;
        currentState = newState;
    }


	// Update is called once per frame
	private void Update () {

        h = Input.GetAxisRaw("Horizontal");
        run(h);
    }

    void run(float h)
    {
        movement.Set(h, 0, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.transform.position + movement);
    }
}
