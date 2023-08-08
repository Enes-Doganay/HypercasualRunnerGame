using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Upgradeable")]
[Serializable]
public class UpgradeSO : ScriptableObject
{
    public int index;
    public string name;
    public int level;
    public float baseCost;
}