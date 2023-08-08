public class AIWinState : AIState
{
    public void Enter(AI ai)
    {
        ai.animator.Play("Win");
        ai.characterController.enabled = false;
    }

    public void Exit(AI ai)
    {
    }

    public AIStateID GetID()
    {
        return AIStateID.Win;
    }

    public void Update(AI ai)
    {
    }

}
