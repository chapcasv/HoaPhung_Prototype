using System.Collections.Generic;

public static class F_Beast 
{
    #region Properties

    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int amount_LV_2 = 4;
    private const float lifeStealLv_1 = 10;
    private const float lifeStealLv_2 = 15;
    private const float critBonusLv_1 = 10;
    private const float critBonusLv_2 = 25;


    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }

    public static float CritBonusLv_2 => critBonusLv_2;

    public static float CritBonusLv_1 => critBonusLv_1;

    public static float LifeStealLv_2 => lifeStealLv_2;

    public static float LifeStealLv_1 => lifeStealLv_1;

    public static int Amount_LV_2 => amount_LV_2;

    public static int Amount_Lv_1 => amount_Lv_1;

    #endregion

    #region Methods

    public static void Set_Beast_by(List<BaseEntiny> listUnit_Beast)
    {
        Amount_Current = listUnit_Beast.Count;

        if (Amount_Current >= Amount_Lv_1 && Amount_Current < Amount_LV_2)
        {
            CritBonus(listUnit_Beast,CritBonusLv_1);
            LifeSteal(listUnit_Beast, LifeStealLv_1);
        }
        else if(Amount_Current >= Amount_LV_2)
        {
            CritBonus(listUnit_Beast, CritBonusLv_2);
            LifeSteal(listUnit_Beast, LifeStealLv_2);
        }
    }

    private static void LifeSteal(List<BaseEntiny> listUnit_Beast, float lifeSteal)
    {
        foreach (BaseEntiny unit in listUnit_Beast)
        {
            unit.LifeSteal = unit.Base_LifeSteal + lifeSteal;
        }
    }

    private static void CritBonus(List<BaseEntiny> listUnit_Beast, float critBonus)
    {
        foreach (BaseEntiny unit in listUnit_Beast)
        {
            unit.Crit = unit.Base_Crit + critBonus;
        }
    }
    #endregion

}
