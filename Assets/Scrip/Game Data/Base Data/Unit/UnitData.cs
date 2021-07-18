[System.Serializable]
public class Unit
{
    public string ID;
    public string Unit_name;
    public string description;
    public string talent_name;
    public string talent_description;
    public string skill_name;
    public string skill_description;
    public UnitClass unitClass;
    public UnitFaction unitFaction;

    public int HP;
    public int Int;
    public int Str;
    public int HP_perLv;
    public int Int_perLv;
    public int Str_perLv;
    public float Atk_Speed;
    public int SP_regen = 5;
    public int SP_max;
    public int SP_current;
    public bool Have_SP_bar;
    public bool Have_Stack_bar;
    public int Cost;

    public float Speed_Projectile = 0;
    public int Position = 0;

    public Item_Database slot1 = null;
    public Item_Database slot2 = null;
    public Item_Database slot3 = null;
    public Item_Database slot4 = null;
    public int Level = 1;
    public int Range;

}


public enum UnitFaction
{   
    VietNam,
    MongNguyen,
    Khmer,
    Champa,
    VietRoyal,
    Thai,
    Tay
}


public enum UnitClass
{     
    Archer,
    Cavalry,
    Infantry,
    Mandarin,
    Marine,
    Partisans,
    RoyalGuard,
    WarElephant
}

