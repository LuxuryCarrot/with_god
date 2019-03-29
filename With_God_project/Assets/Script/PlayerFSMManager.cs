using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    WALK,
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
    public float xMove;
    public float h;
    public Animator animator;

    public Rigidbody rigid;

    Vector3 movement = Vector3.zero;
    bool isJumping;

    Dictionary<PlayerState, PlayerFSMState> states = new Dictionary<PlayerState, PlayerFSMState>();

    private void Awake()
    {
        moveSpeed = 3;
        cc = GetComponent<CharacterController>();

        states.Add(PlayerState.IDLE, GetComponent<Player_S>());
        states.Add(PlayerState.RUN, GetComponent<Player_R>());
        states.Add(PlayerState.WALK, GetComponent<Player_W>());
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
        xMove = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        if (h < 0)
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(xMove, 0, 0));
        }
        if (h > 0)
        {
            animator.SetBool("isWalking", true);
            this.transform.Translate(new Vector3(xMove, 0, 0));
        }

    }
    
  
}
