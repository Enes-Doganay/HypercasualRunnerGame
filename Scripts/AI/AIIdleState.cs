using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIState
{
    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }
    public void Enter(AI ai)
    {
    }
    public void Update(AI ai)
    {
        if (ai.Character.start == true)
        {
            ai.stateMachine.ChangeState(AIStateID.Running);
        }
    }

    public void Exit(AI ai)
    {
    }
}
