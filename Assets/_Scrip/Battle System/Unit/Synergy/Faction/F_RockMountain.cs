using System.Collections.Generic;


//Need UnitTest
public static class F_RockMountain 
{
    #region Properties

    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int hPbonus_Lv_1 = 200;
    private const int amount_Lv_2 = 4;
    private const int hPbonus_Lv_2 = 300;

    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }

    public static int Amount_Lv_1 => amount_Lv_1;

    public static int HPbonus_Lv_1 => hPbonus_Lv_1;

    public static int Amount_Lv_2 => amount_Lv_2;

    public static int HPbonus_Lv_2 => hPbonus_Lv_2;




    #endregion

    #region Methods
    public static void Set_RockMountain_by(List<BaseEntiny> listUnit_RockMountai)
    {
        Amount_Current = listUnit_RockMountai.Count;

        if (Amount_Current >= Amount_Lv_1 && Amount_Current < Amount_Lv_2)
        {
            HP_bonus(listUnit_RockMountai, HPbonus_Lv_1);
        }
        else if (Amount_Current >= Amount_Lv_2) {
            HP_bonus(listUnit_RockMountai, HPbonus_Lv_2);
        }
    }

    private static void HP_bonus(List<BaseEntiny> listUnit_RockMountai, int HP_bonus)
    {
        foreach (BaseEntiny unit in listUnit_RockMountai)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
        }
    }
    #endregion

}
