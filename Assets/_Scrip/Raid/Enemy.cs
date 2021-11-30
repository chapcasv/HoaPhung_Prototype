using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy",menuName ="Raid/Enemy")]
public class Enemy : ScriptableObject
{
    public Card enemy;
    [Range(32,64)][Tooltip("Position enemy spawn in board")]
    public int Pos = 32;

}
