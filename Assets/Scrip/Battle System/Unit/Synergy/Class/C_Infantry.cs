using System.Collections.Generic;

public static class C_Infantry 
{
    #region Properties

    private static int infantryAmount_Current;
    private const int infantryAmount_Lv_1 = 2;
    private const int infantryAmount_Lv_2 = 4;
    private const int infantryAmount_Lv_3 = 6;
    private const int infantry_HP_bonus_Lv_1 = 300;
    private const int infantry_HP_bonus_Lv_2 = 600;
    private const int infantry_HP_bonus_Lv_3 = 1000;
    private const int infantry_Str_bonus_Lv_1 = 40;
    private const int infantry_Str_bonus_Lv_2 = 60;
    private const int infantry_Str_bonus_Lv_3 = 90;

    public static int InfantryAmount_Current { get => infantryAmount_Current; set => infantryAmount_Current = value; }
    public static int InfantryAmount_Lv_1 => infantryAmount_Lv_1;
    public static int InfantryAmount_Lv_2 => infantryAmount_Lv_2;
    public static int InfantryAmount_Lv_3 => infantryAmount_Lv_3;
    public static int Infantry_HP_bonus_Lv_1 => infantry_HP_bonus_Lv_1;
    public static int Infantry_HP_bonus_Lv_2 => infantry_HP_bonus_Lv_2;
    public static int Infantry_HP_bonus_Lv_3 => infantry_HP_bonus_Lv_3;
    public static int Infantry_Str_bonus_Lv_1 => infantry_Str_bonus_Lv_1;
    public static int Infantry_Str_bonus_Lv_2 => infantry_Str_bonus_Lv_2;
    public static int Infantry_Str_bonus_Lv_3 => infantry_Str_bonus_Lv_3;
    #endregion

    #region Methods

    public static void Set_Infantry_by(List<BaseEntiny> listUnit_Infantry)
    {
        InfantryAmount_Current = listUnit_Infantry.Count;

        if (InfantryAmount_Lv_1 <= InfantryAmount_Current && InfantryAmount_Current < InfantryAmount_Lv_2)
        {
            Infantry_HP_bonus(listUnit_Infantry, Infantry_HP_bonus_Lv_1);
            Infantry_Str_bonus(listUnit_Infantry, Infantry_Str_bonus_Lv_1);
        }
        else if (InfantryAmount_Lv_2 <= InfantryAmount_Current && InfantryAmount_Current < InfantryAmount_Lv_3)
        {
            Infantry_HP_bonus(listUnit_Infantry, Infantry_HP_bonus_Lv_2);
            Infantry_Str_bonus(listUnit_Infantry, Infantry_Str_bonus_Lv_2);
        }
        else if (InfantryAmount_Current == InfantryAmount_Lv_3)
        {
            Infantry_HP_bonus(listUnit_Infantry, Infantry_HP_bonus_Lv_3);
            Infantry_Str_bonus(listUnit_Infantry, Infantry_Str_bonus_Lv_3);
        }
    }

    private static void Infantry_HP_bonus(List<BaseEntiny> listUnit_Infantry, int HP_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Infantry)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
            unit.bar.SetMaxHP(unit.HP_max);
        }
    }

    private static void Infantry_Str_bonus(List<BaseEntiny> listUnit_Infantry, int Str_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Infantry)
        {
            unit.Str = unit.Base_Str + Str_bonus;
        }
    }
    #endregion
}
