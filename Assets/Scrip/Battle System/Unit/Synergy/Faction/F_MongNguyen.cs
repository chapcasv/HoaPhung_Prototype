using System.Collections.Generic;

public static class F_MongNguyen 
{
    #region Properties

    private static int mongNguyenAmount_Current;
    private const int mongNguyenAmount_Lv_1 = 3;
    private const int mongNguyenHP_bonus_Lv_1 = 300;

    public static int MongNguyenAmount_Current { get => mongNguyenAmount_Current; set => mongNguyenAmount_Current = value; }
    public static int MongNguyenAmount_Lv_1 => mongNguyenAmount_Lv_1;
    public static int MongNguyenHP_bonus_Lv_1 => mongNguyenHP_bonus_Lv_1;


    #endregion

    #region Methods
    public static void Set_MongNguyen_by(List<BaseEntiny> listUnit_MongNguyen)
    {
        MongNguyenAmount_Current = listUnit_MongNguyen.Count;

        if (MongNguyenAmount_Current == MongNguyenAmount_Lv_1)
        {
            MongNguyen_HP_bonus(listUnit_MongNguyen, MongNguyenHP_bonus_Lv_1);

        }
    }

    private static void MongNguyen_HP_bonus(List<BaseEntiny> listUnit_Vietnam, int HP_bonus)
    {
        foreach (BaseEntiny unit in listUnit_Vietnam)
        {
            unit.HP_max = unit.Base_HP_max + HP_bonus;
            unit.HP_current = unit.HP_max;
        }
    }
    #endregion

}
