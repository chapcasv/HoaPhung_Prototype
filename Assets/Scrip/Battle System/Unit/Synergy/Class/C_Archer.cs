using System.Collections.Generic;

public static class C_Archer 
{
    #region Properties

    private static int archerAmount_Current;
    private const int archerAmount_Lv_1 = 2;
    private const int archerAmount_Lv_2 = 4;
    private const int archer_AtkSpeed_bonus_Lv_1 = 60;
    private const int archer_AtkSpeed_bonus_Lv_2 = 100;
    private const int archer_Str_bonus_Lv_1 = 40;
    private const int archer_Str_bonus_Lv_2 = 60;
    private const int archer_Int_bonus_Lv_1 = 70;
    private const int archer_Int_bonus_Lv_2 = 100;
    private const int archer_decrease_SP_regen = 2;

    public static int ArcherAmount_Current { get => archerAmount_Current; set => archerAmount_Current = value; }
    public static int ArcherAmount_Lv_1 => archerAmount_Lv_1;
    public static int ArcherAmount_Lv_2 => archerAmount_Lv_2;
    public static int Archer_AtkSpeed_bonus_Lv_1 => archer_AtkSpeed_bonus_Lv_1;
    public static int Archer_AtkSpeed_bonus_Lv_2 => archer_AtkSpeed_bonus_Lv_2;
    public static int Archer_Str_bonus_Lv_1 => archer_Str_bonus_Lv_1;
    public static int Archer_Str_bonus_Lv_2 => archer_Str_bonus_Lv_2;
    public static int Archer_Int_bonus_Lv_1 => archer_Int_bonus_Lv_1;
    public static int Archer_Int_bonus_Lv_2 => archer_Int_bonus_Lv_2;
    public static int Archer_decrease_SP_regen => archer_decrease_SP_regen;

    #endregion

    #region Methods
    public static void Set_Archer_by(List<BaseEntiny> listUnit_Archer)
    {
        ArcherAmount_Current = listUnit_Archer.Count;

        if (ArcherAmount_Lv_1 <= ArcherAmount_Current && ArcherAmount_Current < ArcherAmount_Lv_2)
        {
            Archer_AtkSpeed_bonus(listUnit_Archer, Archer_AtkSpeed_bonus_Lv_1);
            Archer_Str_bonus(listUnit_Archer, Archer_Str_bonus_Lv_1);
            Archer_Int_bonus(listUnit_Archer, Archer_Int_bonus_Lv_1);
            Archer_Decrease_SP_regen(listUnit_Archer);

            //Create Effect
        }
        else if (ArcherAmount_Current == ArcherAmount_Lv_2)
        {
            Archer_AtkSpeed_bonus(listUnit_Archer, Archer_AtkSpeed_bonus_Lv_2);
            Archer_Str_bonus(listUnit_Archer, Archer_Str_bonus_Lv_2);
            Archer_Int_bonus(listUnit_Archer, Archer_Int_bonus_Lv_2);
            Archer_Decrease_SP_regen(listUnit_Archer);
        }
    }

    private static void Archer_AtkSpeed_bonus(List<BaseEntiny> listUnit_Archer, int AtkSpeed_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Archer)
        {
            unit.Atk_speed = unit.Base_Atk_speed + ((unit.Base_Atk_speed * AtkSpeed_bonus) / 100);
        }
    }


    private static void Archer_Str_bonus(List<BaseEntiny> listUnit_Archer, int Str_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Archer)
        {
            unit.Str = unit.Base_Str + Str_bonus;
        }
    }

    private static void Archer_Int_bonus(List<BaseEntiny> listUnit_Archer, int Int_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Archer)
        {
            unit.Int = unit.Base_Int + Int_bonus;
        }
    }

    private static void Archer_Decrease_SP_regen(List<BaseEntiny> listUnit_Archer)
    {
        foreach (BaseEntiny unit in listUnit_Archer)
        {
            unit.SP_regen = unit.Base_SP_regen - Archer_decrease_SP_regen;
        }
    }
    #endregion
}
