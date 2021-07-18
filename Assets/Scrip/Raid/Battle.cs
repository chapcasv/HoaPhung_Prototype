using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Battle 
{
    public string battle_name;
    public List<Unit> enemy;
    public int maxAmount;
    public float maxTimeBattle;
}
