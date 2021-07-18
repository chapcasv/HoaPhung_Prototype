using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot_Equip : MonoBehaviour, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    public Item_Database item_data;
    public Image icon;
    public bool ShowToolTip = true;
    public Item item;

    private string ID_hero_chosen;
    private Player_Database data;
    private UnitOfPlayer hero;

    public void OnDrop(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag != null)
        {
            //Tham chiếu item data trong slot inventory sang slot equipment

            item = eventData.pointerDrag.transform.GetComponent<InventorySlot>().item;
            item_data = eventData.pointerDrag.transform.GetComponent<InventorySlot>().item_data;
            icon.sprite = item.icon;

            Save_Hero_Equipment();
            Reload_Hero_Stat_after_Equipment();
            Remove_Item_In_Inventory(eventData.pointerDrag.transform.GetComponent<InventorySlot>().item_data);
        }
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        if (item_data != null && ShowToolTip)
        {
            Tooltip_for_item.Show_tooltip(icon.sprite, item_data.Item_name, item_data.opt1_discription, item_data.opt2_discription, item_data.opt3_discription);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Tooltip_for_item.Hiden_tooltip();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {   
            if(item_data != null)
            {
                InventoryUI.instance.list_Item_in_inventory.Add(item_data);
                Clear();
            }
        }
    }

    void Remove_Item_In_Inventory(Item_Database item_in_inventory)
    {
        data = Save_System.LoadPlayer();
        Debug.Log(InventoryUI.instance.list_Item_in_inventory.Count);
        Debug.Log(item_in_inventory.Item_name);
        if (InventoryUI.instance.list_Item_in_inventory.Remove(item_in_inventory))
        {
            data.item_list = InventoryUI.instance.list_Item_in_inventory;
            Debug.Log(InventoryUI.instance.list_Item_in_inventory.Count);
            Save_System.SaveData(data);
        }  
    }

    void Reload_Hero_Stat_after_Equipment()
    {
        data = Save_System.LoadPlayer();
        ID_hero_chosen = Display_My_list_hero.GetID_hero_chosen();
        hero = Save_System.GetHero_Database_From_ID(data, ID_hero_chosen);
        Display_My_list_hero.instance.Show_stat(hero);
    }

    void Save_Hero_Equipment()
    {
        data = Save_System.LoadPlayer();
        Display_My_list_hero.instance.Save_Item_Equipment(data);
    }
    private void Clear()
    {
        item = DataGraph.Get_Item_Default();
        icon.sprite = item.icon;
        item_data = Convert_Data.Convert_Item_to_Item_database(item);
        Save_Hero_Equipment();
        Reload_Hero_Stat_after_Equipment();

    }

    
}
