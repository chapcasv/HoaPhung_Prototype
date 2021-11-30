using System.Collections.Generic;

public static class C_Cavalry
{
    #region Properties

    private static int cavalryAmount_Current;
    private const int cavalryAmount_Lv_1 = 2;
    private const int cavalryAmount_Lv_2 = 4;
    private const int cavalryAmount_Lv_3 = 6;
    private const int cavalry_AtkSpeed_bonus_Lv_1 = 20;
    private const int cavalry_AtkSpeed_bonus_Lv_2 = 40;
    private const int cavalry_AtkSpeed_bonus_Lv_3 = 80;
    private const int cavalry_Recdution_Meleedame_bonus_Lv_1 = 15;
    private const int cavalry_Recdution_Meleedame_bonus_Lv_2 = 20;
    private const int cavalry_Recdution_Meleedame_bonus_Lv_3 = 25;
    private const int cavalry_movespeed_increase = 1;

    public static int CavalryAmount_Current { get => cavalryAmount_Current; set => cavalryAmount_Current = value; }
    public static int CavalryAmount_Lv_1 => cavalryAmount_Lv_1;
    public static int CavalryAmount_Lv_2 => cavalryAmount_Lv_2;
    public static int CavalryAmount_Lv_3 => cavalryAmount_Lv_3;
    public static int Cavalry_AtkSpeed_bonus_Lv_1 => cavalry_AtkSpeed_bonus_Lv_1;
    public static int Cavalry_AtkSpeed_bonus_Lv_2 => cavalry_AtkSpeed_bonus_Lv_2;
    public static int Cavalry_AtkSpeed_bonus_Lv_3 => cavalry_AtkSpeed_bonus_Lv_3;
    public static int Cavalry_Recdution_Meleedame_bonus_Lv_1 => cavalry_Recdution_Meleedame_bonus_Lv_1;
    public static int Cavalry_Recdution_Meleedame_bonus_Lv_2 => cavalry_Recdution_Meleedame_bonus_Lv_2;
    public static int Cavalry_Recdution_Meleedame_bonus_Lv_3 => cavalry_Recdution_Meleedame_bonus_Lv_3;
    public static int Cavalry_movespeed_increase => cavalry_movespeed_increase;

    #endregion

    #region Methods
    public static void Set_Cavalry_by(List<BaseEntiny> listUnit_Cavalry)
    {
        CavalryAmount_Current = listUnit_Cavalry.Count;

        if (CavalryAmount_Lv_1 <= CavalryAmount_Current && CavalryAmount_Current < CavalryAmount_Lv_2)
        {
            Cavalry_AtkSpeed_bonus(listUnit_Cavalry, Cavalry_AtkSpeed_bonus_Lv_1);
            Cavalry_MoveSpeed_bonus(listUnit_Cavalry, Cavalry_movespeed_increase);
            Cavalry_Melee_Reduction_Bonus(listUnit_Cavalry, Cavalry_Recdution_Meleedame_bonus_Lv_1);
        }
        else if (CavalryAmount_Lv_2 <= CavalryAmount_Current && CavalryAmount_Current < CavalryAmount_Lv_3)
        {
            Cavalry_AtkSpeed_bonus(listUnit_Cavalry, Cavalry_AtkSpeed_bonus_Lv_2);
            Cavalry_MoveSpeed_bonus(listUnit_Cavalry, Cavalry_movespeed_increase);
            Cavalry_Melee_Reduction_Bonus(listUnit_Cavalry, Cavalry_Recdution_Meleedame_bonus_Lv_2);
        }
        else if (CavalryAmount_Current == CavalryAmount_Lv_3)
        {
            Cavalry_AtkSpeed_bonus(listUnit_Cavalry, Cavalry_AtkSpeed_bonus_Lv_3);
            Cavalry_MoveSpeed_bonus(listUnit_Cavalry, Cavalry_movespeed_increase);
            Cavalry_Melee_Reduction_Bonus(listUnit_Cavalry, Cavalry_Recdution_Meleedame_bonus_Lv_3);
        }
    }

    private static void Cavalry_AtkSpeed_bonus(List<BaseEntiny> listUnit_Cavalry, int AtkSpeed_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Cavalry)
        {
            unit.Atk_speed = unit.Base_Atk_speed + ((unit.Base_Atk_speed * AtkSpeed_bonus) / 100);
        }
    }

    private static void Cavalry_MoveSpeed_bonus(List<BaseEntiny> listUnit_Cavalry, int MoveSpeed_Bonus)
    {
        foreach (BaseEntiny unit in listUnit_Cavalry)
        {
            unit.movespeed = unit.Base_movespeed + MoveSpeed_Bonus;
        }
    }

    private static void Cavalry_Melee_Reduction_Bonus(List<BaseEntiny> listUnit_Cavalry, int Melee_Reduction_Bonus)
    {
        foreach (BaseEntiny unit in listUnit_Cavalry)
        {
            unit.PhysicReduction = Melee_Reduction_Bonus;
        }
    }
    #endregion
}
