using UnityEngine;
public class AIRunningState : AIState
{
    float newXPos = 0f;
    float x;
    public AIStateID GetID()
    {
        return AIStateID.Running;
    }
    public void Enter(AI ai)
    {
        ai.animator.SetBool("Start", true);
    }
    void AIState.Update(AI ai)
    {
        var midRay = new Ray(ai.midRayObj.transform.position, ai.midRayObj.transform.forward);
        var leftRay = new Ray(ai.leftRayObj.transform.position, ai.leftRayObj.transform.forward);
        var rightRay = new Ray(ai.rightRayObj.transform.position, ai.rightRayObj.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(midRay, out hit, 5f))
        {
            if (hit.collider.tag == "Obstacle")
            {
                {
                    if (!Physics.Raycast(leftRay, out hit, 3f) && ai.transform.position.x > -1f)
                    {
                        {
                            if (ai.transform.position.x > 1f)
                                newXPos = 0;
                            else
                                newXPos = -2f;
                            ai.animator.Play("Left");
                        }
                    }
                    else if (!Physics.Raycast(rightRay, out hit, 3f) && ai.transform.position.x < 1f)
                    {
                        {
                            if (ai.transform.position.x < -1f)
                                newXPos = 0;
                            else
                                newXPos = 2f;
                            ai.animator.Play("Right");
                        }
                    }
                }
            }
        }

        x = Mathf.Lerp(x, newXPos, Time.deltaTime * 10);
        Vector3 moveVector = new Vector3(x - ai.transform.position.x, ai.y * Time.deltaTime,ai.moveSpeed * Time.deltaTime);
        ai.characterController.Move(moveVector);

        if (ai.collisionDetection.collisionDetected)
            ai.stateMachine.ChangeState(AIStateID.Death);

        if (ai.collisionDetection.won)
            ai.stateMachine.ChangeState(AIStateID.Win);

    }
    public void Exit(AI ai)
    {

    }
}
