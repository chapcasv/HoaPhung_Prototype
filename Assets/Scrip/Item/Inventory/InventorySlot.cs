using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image icon;
    public Item_Database item_data;
    public Item item;
    public bool ShowToolTip = true;

    public void AddItem(Item new_item, Item_Database item_data)
    {
        item = new_item;
        this.item_data = item_data;
        icon.sprite = new_item.icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (item != null && ShowToolTip)
        {
            Tooltip_for_item.Show_tooltip(icon.sprite, item.Item_name, item.opt_1_discription, item.opt_2_discription, item.opt_3_discription);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Tooltip_for_item.Hiden_tooltip();
    }
}
