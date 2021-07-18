using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_Database 
{
    public string P_name;
    public int level;
    public int food;
    public int money;
    public List<UnitOfPlayer> hero_list;
    public List<Item_Database> item_list;
    public List<Team_database> team_list;
    public int Max_member;
    public int Max_cost;
    public int Team_selected;

    public Player_Database(Player player)
    {
        P_name = player.P_name;
        level = player.level;
        food = player.food;
        money = player.money;
        hero_list = player.hero_database;
        item_list = player.item_database;
        team_list = player.team_database;
        Max_member = player.Max_member;
        Max_cost = player.Max_cost;
        Team_selected = player.Team_Selected;
    }
}
