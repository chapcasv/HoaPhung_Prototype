using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Danh sách các item đã có sprite, và các chỉ số gốc
/// </summary>
[CreateAssetMenu(fileName ="ItemDatabase", menuName = "Items/Item DataBase")]
public class ItemDatabase: ScriptableObject
{
    public List<Item> allitems;
}
