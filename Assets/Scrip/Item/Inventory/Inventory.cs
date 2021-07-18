using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    const int maxSlot = 30;
    
    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;

    }


    public void Add(Item i)
    {    
        if (Have_slot_inventory())
        {
            Item_Database newItem = Convert_Data.Convert_Item_to_Item_database(i);
            Debug.Log("copy new item - Inventory.cs");
            var data = Save_System.LoadPlayer();
            data.item_list.Add(newItem);
            Save_System.SaveData(data);
            InventoryUI.instance.Load_PlayerData_to_Inventory();
            
        }
    }
    public void Remove (Item i)
    {
        this.Remove(i);
    }

    public bool Have_slot_inventory()
    {
        var data = Save_System.LoadPlayer();

        if (data.item_list.Count < maxSlot)
        {
            return true;
        }
        else
        {
            Debug.Log("dont have slot"); 
            return false;
        }
    }
    

    public void TEST_create_new_item()
    {
        Item newItem = DataGraph.Get_Item_ByID("I002");
        Debug.Log("ID: "+ newItem.ID);
        if (!Have_slot_inventory()) return;
        this.Add(newItem);

        var data = Save_System.LoadPlayer();
        data.Max_cost = 10;
        data.Max_member = 10;
        Save_System.SaveData(data);

    }
    
}
