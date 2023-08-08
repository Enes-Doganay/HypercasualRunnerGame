using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AI", menuName = "AIData")]
public class AIData : ScriptableObject
{
    public float moveSpeed;
    public float dodgeSpeed;
    public float jumpPower;
}
