using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Wave", menuName ="Raid/Wave")]
public class Wave : ScriptableObject
{
    public List<Enemy> enemys;
    [Range(0,200)] [Tooltip("Gold bonus after clear all enemy in wave")]
    public int GoldBonus;
}
