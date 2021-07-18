using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Lưu trữ các item của player
/// </summary>
[System.Serializable]


public class Item_Database
{
    public string ID;
    public string Item_name;
    public ItemType type;
    public string opt1_discription;
    public string opt2_discription;
    public string opt3_discription;


    public StatType stat_opt1;
    public float value_stat_opt1;

    public StatType stat_opt2;
    public float value_stat_opt2;


}
