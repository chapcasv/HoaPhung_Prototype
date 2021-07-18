using System.Collections.Generic;

public static class F_ChamPa 
{
    #region Properties

    private static int chamPaAmount_Current;
    private const int chamPaAmount_Lv_1 = 3;
    private const int chamPa_atkSpeedBonusLv_1 = 50;

    public static int ChamPaAmount_Current { get => chamPaAmount_Current; set => chamPaAmount_Current = value; }
    public static int ChamPaAmount_Lv_1 => chamPaAmount_Lv_1;
    public static int ChamPa_atkSpeedBonusLv_1 => chamPa_atkSpeedBonusLv_1;

    #endregion

    #region Methods

    public static void Set_ChamPa_by(List<BaseEntiny> listUnit_ChamPa)
    {
        ChamPaAmount_Current = listUnit_ChamPa.Count;

        if (ChamPaAmount_Current == ChamPaAmount_Lv_1)
        {
            ChamPa_AtkSpeedBonus(listUnit_ChamPa, ChamPa_atkSpeedBonusLv_1);

        }
    }

    private static void ChamPa_AtkSpeedBonus(List<BaseEntiny> listUnit_Vietnam, int ATKs_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Vietnam)
        {
            unit.Atk_speed = unit.Base_Atk_speed + ((unit.Base_Atk_speed * 100) / ATKs_bonus);
        }
    }
    #endregion

}
