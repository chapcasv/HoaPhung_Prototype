using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =("List Effect"),menuName =("Effect/List Effect"))]
public class AllEffect : ScriptableObject
{
    public List<EffectATK> all_effectAtk;
    public List<EffectSkill> all_effectSkill;
}
