using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedBuff : Buff
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(ApplyToPlayer(Character.Instance.moveSpeed));
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "AI")
        {
            aI = other.gameObject.GetComponentInParent<AI>();
            StartCoroutine(ApplyToAI(aI, aI.moveSpeed));
            Destroy(this.gameObject);
        }

    }
    protected override void TakeBackBuffPlayer(float buff = 0, float defaultValue = 0)
    {
        base.TakeBackBuffPlayer(Character.Instance.moveSpeed, Character.Instance.SetMoveSpeed());
    }
    protected override void TakeBackBuffAI(float buff = 0, float defaultValue = 0)
    {
        base.TakeBackBuffAI(aI.moveSpeed, aI.SetMoveSpeed());
    }
}
