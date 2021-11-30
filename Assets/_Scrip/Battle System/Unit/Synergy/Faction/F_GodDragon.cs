using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_GodDragon : MonoBehaviour
{
    private static int amount_Current;
    private const int amount_Lv_1 = 2;
    private const int amount_Lv_2 = 3;
    private const int magicReduction_Lv_1 = 40;
    private const int magicReduction_Lv_2 = 60;

    public static int Amount_Lv_1 => amount_Lv_1;

    public static int MagicR_bonus_Lv1 => magicReduction_Lv_1;

    public static int Amount_Current { get => amount_Current; set => amount_Current = value; }

    public static int Amount_Lv_2 => amount_Lv_2;

    public static int MagicR_bonus_Lv_2 => magicReduction_Lv_2;

    public static void Set_GodDragon_by(List<BaseEntiny> listUnit_GodDragon)
    {
        Amount_Current = listUnit_GodDragon.Count;

        if (Amount_Current >= Amount_Lv_1 && Amount_Current < Amount_Lv_2)
        {
            MagicR_bonus(listUnit_GodDragon, MagicR_bonus_Lv1);
            CC_immune(listUnit_GodDragon);
        }
        else if(Amount_Current >= Amount_Lv_2)
        {
            MagicR_bonus(listUnit_GodDragon, MagicR_bonus_Lv_2);
            CC_immune(listUnit_GodDragon);
        }
    }

    private static void MagicR_bonus(List<BaseEntiny> listUnit_GodDragon, int MagicR_bonus)
    {
        foreach (BaseEntiny unit in listUnit_GodDragon)
        {
            unit.MagicReduction = unit.Base_MagicReduction + MagicR_bonus;
        }
    }

    private static void CC_immune(List<BaseEntiny> listUnit_GodDragon)
    {
        foreach (var unit in listUnit_GodDragon)
        {
            unit.cc_immune = true;
        }
    }
}
