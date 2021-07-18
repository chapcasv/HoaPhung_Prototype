using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataGraph : MonoBehaviour
{
    public ItemDatabase item;
    public ListUnitGraph listUnitGraph;
    public AllEffect allEffect_Atk;


    private static DataGraph instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static EffectATK Get_Effect_Atk_By_ID(string id)
    {
        return instance.allEffect_Atk.all_effectAtk.FirstOrDefault(i => i.ID == id);
    }

    public static EffectSkill Get_Effect_Skill_By_ID(string id)
    {
        return instance.allEffect_Atk.all_effectSkill.FirstOrDefault(i => i.ID == id);
    }

    public static UnitGraph Get_Graph_ByID(string id)
    {
        return instance.listUnitGraph.allUnitGraph.FirstOrDefault(i => i.UnitID == id);
    }

    
    public static Item Get_Item_ByID(string id)
    {
        return instance.item.allitems.FirstOrDefault(i => i.ID == id);
    }
    public static List<Item> Get_All_Item()
    {
        return instance.item.allitems;
    }
   

    public static Item Get_Item_Default()
    {
        return instance.item.allitems[0];
    }
}
