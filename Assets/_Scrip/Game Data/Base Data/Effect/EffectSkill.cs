using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = ("EffectSkill"), menuName = ("Effect/EffectSkill"))]
public class EffectSkill : ScriptableObject
{
    public Transform effect;
    public CardUnitID ID;

}
