using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator animater;
    public PlayerStateMachine stateMachine;

    private const string PARAM_IS_MOVING = "IsMoving";
    private const string PARAM_IS_RUNNING = "IsRunning";
    private const string PARAM_IS_JUMPING = "IsJumping";
    private const string PARAM_IS_FALLING = "IsFalling";
    private const string PARAM_ATTACK_TRIGGER = "Attack";

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (stateMachine.currenState != null)
        {
            ResetAllBoolParameters();

            switch(stateMachine.currenState)
            {
                case IdleState:
                    break;
                case MovingState:
                    animater.SetBool(PARAM_IS_MOVING, true);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        animater.SetBool(PARAM_IS_RUNNING, true);
                    }
                    break;
                case JumpingState:
                    animater.SetBool(PARAM_IS_JUMPING, true);
                    break;
                case FallingState:
                    animater.SetBool(PARAM_IS_FALLING, true);
                    break;
            }
        }
    }

    private void TriggerAttack()
    {
        animater.SetTrigger(PARAM_ATTACK_TRIGGER);
    }

    private void ResetAllBoolParameters()
    {
        animater.SetBool(PARAM_IS_MOVING, false);
        animater.SetBool(PARAM_IS_RUNNING, false);
        animater.SetBool(PARAM_IS_JUMPING, false);
        animater.SetBool(PARAM_IS_FALLING, false);
    }

}
