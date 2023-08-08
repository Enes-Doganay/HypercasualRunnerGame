using UnityEngine;

public class ThrowRock : Skill
{
    public override void UseSkill(float forceValue)
    {
        base.UseSkill(forceVal);
    }
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.tag == "Obstacle")
        {
            collision.rigidbody.isKinematic = false;
            ApplySkill();
        }
    }
    public override void ApplySkillToPlayer()
    {
        base.ApplySkillToPlayer();
        Character.Instance.enabled = false;
        Character.Instance.gameObject.GetComponentInChildren<Ragdoll>().ActivateRagdoll();
        UIManager.Instance.SetGameOverPanel();
    }
    public override void ApplySkillToAI(AI aI)
    {
        base.ApplySkillToAI(aI);
        aI.stateMachine.ChangeState(AIStateID.Death);
    }
    public override void ApplySkill()
    {
        base.ApplySkill();
        Destroy(this.gameObject, 1f);
    }
}
