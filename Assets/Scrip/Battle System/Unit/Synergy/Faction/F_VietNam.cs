using System.Collections.Generic;
using System.Diagnostics;

public static class F_VietNam
{
    #region Properties

    private static int vietnamAmount_Current;
    private const int vietnamrAmount_Lv_1 = 3;
    private const int vietnam_HP_bonus_Lv_1 = 299;
    public static int VietnamrAmount_Lv_1 => vietnamrAmount_Lv_1;
    public static int Vietnam_HP_bonus_Lv_1 => vietnam_HP_bonus_Lv_1;
    public static int VietnamAmount_Current { get => vietnamAmount_Current; set => vietnamAmount_Current = value; }

    #endregion

    #region Methods
    public static void Set_Vietnam_by(List<BaseEntiny> listUnit_Vietnam)
    {
        VietnamAmount_Current = listUnit_Vietnam.Count;
        
        if (VietnamAmount_Current == VietnamrAmount_Lv_1)
        {
            Vietnam_HP_bonus(listUnit_Vietnam, Vietnam_HP_bonus_Lv_1);

        }
    }

    private static void Vietnam_HP_bonus(List<BaseEntiny> listUnit_Vietnam, int HP_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Vietnam)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
        }
    }
    #endregion
}
