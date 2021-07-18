using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class My_hero_list_Inventory : MonoBehaviour
{
    public Transform item_parent;
    public List<Item_Database> item_Inventory;

    private InventorySlot[] slots;
    
    void Start()
    {
        //inventory = Inventory.instance;
        slots = item_parent.GetComponentsInChildren<InventorySlot>();
    }


    void Update()
    {
        Update_Inventory();
    }

    void Update_Inventory()
    {
        item_Inventory = InventoryUI.instance.list_Item_in_inventory;

        if(item_Inventory == null) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < item_Inventory.Count)
            {
                //Debug.Log("Iventory_mylist_hero:  Count" + data.item_list.Count);
                slots[i].AddItem(Convert_Data.Convert_Item_database_to_Item(item_Inventory[i]),item_Inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    
}
