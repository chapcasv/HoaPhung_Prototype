using System.Collections.Generic;

public static class C_Hunter 
{
    #region Properties

    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int amount_Lv_2 = 4;
    private const int atkSpeed_bonus_Lv_1 = 60;
    private const int atkSpeed_bonus_Lv_2 = 100;
    private const int str_bonus_Lv_1 = 40;
    private const int str_bonus_Lv_2 = 60;
    private const int int_bonus_Lv_1 = 70;
    private const int int_bonus_Lv_2 = 100;
    private const int decrease_SP_regen = 2;

    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }
    public static int Amount_Lv_1 => amount_Lv_1;
    public static int Amount_Lv_2 => amount_Lv_2;
    public static int AtkSpeed_bonus_Lv_1 => atkSpeed_bonus_Lv_1;
    public static int AtkSpeed_bonus_Lv_2 => atkSpeed_bonus_Lv_2;
    public static int Str_bonus_Lv_1 => str_bonus_Lv_1;
    public static int Str_bonus_Lv_2 => str_bonus_Lv_2;
    public static int Int_bonus_Lv_1 => int_bonus_Lv_1;
    public static int Int_bonus_Lv_2 => int_bonus_Lv_2;
    public static int Decrease_SP_regen => decrease_SP_regen;

    #endregion

    #region Methods
    public static void Set_Hunter_by(List<BaseEntiny> Units)
    {
        Amount_Current = Units.Count;

        if (Amount_Lv_1 <= Amount_Current && Amount_Current < Amount_Lv_2)
        {
            AtkSpeed_bonus(Units, AtkSpeed_bonus_Lv_1);
            Str_bonus(Units, Str_bonus_Lv_1);
            Int_bonus(Units, Int_bonus_Lv_1);
            Decrease_SP_Regen(Units);

            //Create Effect
        }
        else if (Amount_Current == Amount_Lv_2)
        {
            AtkSpeed_bonus(Units, AtkSpeed_bonus_Lv_2);
            Str_bonus(Units, Str_bonus_Lv_2);
            Int_bonus(Units, Int_bonus_Lv_2);
            Decrease_SP_Regen(Units);
        }
    }

    private static void AtkSpeed_bonus(List<BaseEntiny> Units, int AtkSpeed_bonus)
    {
        foreach (BaseEntiny unit in Units)
        {
            unit.Atk_speed = unit.Base_Atk_speed + ((unit.Base_Atk_speed * AtkSpeed_bonus) / 100);
        }
    }


    private static void Str_bonus(List<BaseEntiny> Units, int Str_bonus)
    {
        foreach (BaseEntiny unit in Units)
        {
            unit.Str = unit.Base_Str + Str_bonus;
        }
    }

    private static void Int_bonus(List<BaseEntiny> Units, int Int_bonus)
    {
        foreach (BaseEntiny unit in Units)
        {
            unit.Int = unit.Base_Int + Int_bonus;
        }
    }

    private static void Decrease_SP_Regen(List<BaseEntiny> Units)
    {
        foreach (BaseEntiny unit in Units)
        {
            unit.SP_regen = unit.Base_SP_regen - Decrease_SP_regen;
        }
    }
    #endregion
}
