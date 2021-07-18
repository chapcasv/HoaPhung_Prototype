using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class Convert_Data 
{   

    /// <summary>
    /// Chuyển 1 item từ data của game vào danh sách những item của player
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static Item_Database Convert_Item_to_Item_database(Item i)
    {
        Item_Database newItem = new Item_Database();
        newItem.ID = i.ID;
        newItem.type = i.type;
        newItem.Item_name = i.Item_name;
        newItem.opt1_discription = i.opt_1_discription;
        newItem.opt2_discription = i.opt_2_discription;
        newItem.opt3_discription = i.opt_3_discription;

        newItem.stat_opt1 = i.stat_opt1;
        newItem.stat_opt2 = i.stat_opt2;
        newItem.value_stat_opt1 = i.value_stat_opt1;
        newItem.value_stat_opt2 = i.value_stat_opt2;

        return newItem;
    }

    public static Item Convert_Item_database_to_Item(Item_Database i)
    {
        Item newItem = DataGraph.Get_Item_ByID(i.ID);
        return newItem;
    }

}
