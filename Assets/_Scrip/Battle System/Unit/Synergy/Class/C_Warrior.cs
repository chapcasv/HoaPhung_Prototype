using System.Collections.Generic;

public static class C_Warrior 
{
    #region Properties

    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int amount_Lv_2 = 4;
    private const int amount_Lv_3 = 6;
    private const int hP_bonus_Lv_1 = 300;
    private const int hP_bonus_Lv_2 = 600;
    private const int hP_bonus_Lv_3 = 1000;

    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }
    public static int Amount_Lv_1 => amount_Lv_1;
    public static int Amount_Lv_2 => amount_Lv_2;
    public static int Amount_Lv_3 => amount_Lv_3;
    public static int HP_bonus_Lv_1 => hP_bonus_Lv_1;
    public static int HP_bonus_Lv_2 => hP_bonus_Lv_2;
    public static int HP_bonus_Lv_3 => hP_bonus_Lv_3;

    #endregion

    #region Methods

    public static void Set_Warrior_by(List<BaseEntiny> Units)
    {
        Amount_Current = Units.Count;

        if (Amount_Lv_1 <= Amount_Current && Amount_Current < Amount_Lv_2)
        {
            HP_bonus(Units, HP_bonus_Lv_1);
        }
        else if (Amount_Lv_2 <= Amount_Current && Amount_Current < Amount_Lv_3)
        {
            HP_bonus(Units, HP_bonus_Lv_2);
        }
        else if (Amount_Current == Amount_Lv_3)
        {
            HP_bonus(Units, HP_bonus_Lv_3);
        }
    }

    private static void HP_bonus(List<BaseEntiny> Units, int HP_bonus)
    {
        foreach (BaseEntiny unit in Units)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
            unit.bar.SetMaxHP(unit.HP_max);
        }
    }

    #endregion
}
