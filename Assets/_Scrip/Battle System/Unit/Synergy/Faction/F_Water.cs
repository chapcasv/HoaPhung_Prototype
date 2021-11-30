using System.Collections.Generic;
using System.Diagnostics;

public static class F_Water
{
    #region Properties

    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int Def_Lv_1 = 40;
    private const int hP_regenAfter4hit_Lv1 = 30;

    public static int Amount_Lv_1 => amount_Lv_1;
    public static int Def_bonus_Lv_1 => Def_Lv_1;
    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }
    public static int HP_regenAfter4hit_Lv1 => hP_regenAfter4hit_Lv1;

    #endregion

    #region Methods
    public static void Set_Water_by(List<BaseEntiny> listUnit_Water)
    {
        Amount_Current = listUnit_Water.Count;
        
        if (Amount_Current == Amount_Lv_1)
        {
            HP_bonus(listUnit_Water, Def_bonus_Lv_1);

        }
    }

    private static void HP_bonus(List<BaseEntiny> listUnit_Water, int HP_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Water)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
        }
    }
    #endregion
}
