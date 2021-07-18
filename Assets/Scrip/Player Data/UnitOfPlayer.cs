using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UnitOfPlayer 
{
    #region Hero Description
    public string HeroID;
    public string Hero_name;
    public string description;
    #endregion
    #region Skill and Talent

    public string talent_name;
    public string talent_description;

    public string skill_name;
    public string skill_description;

    public UnitClass unitClass;
    public UnitFaction unitFaction;

    #endregion
    #region Stat
    public int HP;
    public int Int;
    public int Str;
    public int HP_perLv;
    public int Int_perLv;
    public int Str_perLv;
    
    public float Atk_Speed;
    public int SP_regen;
    public int SP_max;
    public int SP_current;

    public bool Have_SP_bar;
    public bool Have_stack_bar;
    public int Range;
    public float Speed_projectile;
    public int Crit;

    public int level;
    public int exp_current;
    public int exp_max;
    public float movespeed;
    public int Cost;
    #endregion
    #region Item
    public Item_Database slot1;
    public Item_Database slot2;
    public Item_Database slot3;
    public Item_Database slot4;

    
    #endregion
    public List<int> Position_on_team = new List<int>() { 0, 0, 0 };
 
}


