using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Tạo ra các item có icon và dùng chỉ số gốc
/// </summary>
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string Item_name;
    public ItemType type;
    public string ID;
    public Sprite icon;

    public string opt_1_discription;
    public string opt_2_discription;
    public string opt_3_discription;

    public Dictionary<StatType, int> opt_1;
    public Dictionary<StatType, int> opt_2;

    public StatType stat_opt1;
    public float value_stat_opt1;

    public StatType stat_opt2;
    public float value_stat_opt2;

}

public enum StatType
{
    Str,
    Int,
    HP,
    Atk_speed,
    Sp_regen,
    Sp_current
}

public enum ItemType
{
    Equipment,
    ExpBook,
}
