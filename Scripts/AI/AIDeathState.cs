using UnityEngine;

public class AIDeathState : AIState
{
    public AIStateID GetID()
    {
        return AIStateID.Death;
    }
    public void Enter(AI ai)
    {
        ai.ragdoll.ActivateRagdoll();
        Debug.Log(AIStateID.Death);
    }
    public void Update(AI ai)
    {
    }

    public void Exit(AI ai)
    {
    }





}
