using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourOil : Skill
{
    private void Start()
    {
        forceVal = -2f;
    }
    public override void UseSkill(float forceValue)
    {
        base.UseSkill(0f);
    }
    public override void SetSpawnPoint()
    {
        spawnPoint = new Vector3(Character.Instance.transform.position.x, ability.abilityPrefab.transform.position.y, Character.Instance.transform.position.z - 2.5f);
    }
}
