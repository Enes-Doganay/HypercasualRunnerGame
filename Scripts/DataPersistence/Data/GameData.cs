using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public int level;
    public int gold;

    public GameData()
    {
        this.level = 1;
        this.gold = 0;
    }
}
