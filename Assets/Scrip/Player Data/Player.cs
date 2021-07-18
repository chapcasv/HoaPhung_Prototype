using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{

    public string P_name;
    public int level;
    public int food;
    public int money;
    public List<UnitOfPlayer> hero_database;
    public List<Item_Database> item_database;
    public List<Team_database> team_database;

    public int Max_member;
    public int Max_cost;
    public int Team_Selected;

    public Text Display_player_name;
    public Text Display_level;
    public Text Display_food;
    public Text Display_money;

    

    public void Save_Player_data()
    {
        Save_System.SavePlayer(this);
    }
    public void Load_Player_data()
    {
        Player_Database data = Save_System.LoadPlayer();
        Display_Player_data(data);


    }
    public void Display_Player_data(Player_Database data)
    {
        Display_player_name.text = data.P_name;
        Display_level.text = data.level.ToString();
        Display_food.text = data.food.ToString();
        Display_money.text = data.money.ToString();
    }

}
