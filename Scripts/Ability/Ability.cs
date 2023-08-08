using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="Power",menuName ="SpecialPower")]
public class Ability : ScriptableObject
{
    public enum AbilityType { Buff,Skill};
    public AbilityType abilityType;
    public int id;
    public string name;
    public GameObject abilityPrefab;
    public Sprite sprite;
}