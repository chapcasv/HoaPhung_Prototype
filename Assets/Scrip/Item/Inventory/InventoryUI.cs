using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Transform item_parent; 
    public static InventoryUI instance;
    public List<Item_Database> list_Item_in_inventory;

    private InventorySlot[] slots;
    private Player_Database data;

    private void Awake()
    {
        instance = this;
        list_Item_in_inventory = new List<Item_Database>();
    }

    void Start()
    {
        Load_PlayerData_to_Inventory();
        slots = item_parent.GetComponentsInChildren<InventorySlot>();
        
    }

    private void Update()
    {
        
        Updata_InventoryUI();
    }

    public void Load_PlayerData_to_Inventory()
    {
        data = Save_System.LoadPlayer();
        list_Item_in_inventory.Clear();
        foreach(Item_Database item_data in data.item_list)
        {
            list_Item_in_inventory.Add(item_data);
        }
    }
    public void Save_Inventory_to_PlayerData()
    {
        data = Save_System.LoadPlayer();
        data.item_list = list_Item_in_inventory;
        Save_System.SaveData(data);
    }

    public void Updata_InventoryUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if(i < list_Item_in_inventory.Count)
            {
               
                slots[i].AddItem(Convert_Data.Convert_Item_database_to_Item(list_Item_in_inventory[i]),list_Item_in_inventory[i]); 
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }


}
