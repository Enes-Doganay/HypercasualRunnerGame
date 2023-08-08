using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Character",menuName ="CharacterData")]
public class CharacterData : ScriptableObject
{
    public float moveSpeed;
    public float dodgeSpeed;
    public float jumpPower;
    public int level;
    public float gold;
}
