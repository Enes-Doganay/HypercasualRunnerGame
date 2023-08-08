using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine
{
    public AIState[] states;
    public AI ai;
    public AIStateID currentState;
    public AIStateMachine(AI ai)
    {
        this.ai = ai;
        int numStates = System.Enum.GetNames(typeof(AIStateID)).Length;
        states = new AIState[numStates];
    }
    public void RegisterState(AIState state)
    {
        int index = (int)state.GetID();
        states[index] = state;
    }
    public AIState GetState(AIStateID stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        GetState(currentState)?.Update(ai);
    }
    public void ChangeState(AIStateID newState)
    {
        GetState(currentState)?.Exit(ai);
        currentState = newState;
        GetState(currentState)?.Enter(ai);
    }
    public void death()
    {
        ChangeState(AIStateID.Death);
    }
}
