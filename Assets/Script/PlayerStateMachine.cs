using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currenState;
    public PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        if (currenState != null)
        {
            currenState.Update();
        }
    }
    private void FixedUpdate()
    {
        if (currenState != null)
        {
            currenState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newstate)
    {
        if(currenState?.GetType() != newstate.GetType())
        {
            return;
        }

        currenState?.Exit();

        currenState = newstate;

        currenState.Enter();

        Debug.Log($"상태 전환 되는 스테이트 : {newstate.GetType().Name}");
    }
}
