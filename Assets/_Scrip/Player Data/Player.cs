using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{

    public string pName;
    public int level;
    public int exp;
    public int runeCoin;
    public int money;
    public List<PlayerCard> playerAllCard;
    public List<PlayerDeck> playerAllDeck;

    public int maxDeckAmount;
    public int deckDefault;

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
        Display_food.text = data.runeCoin.ToString();
        Display_money.text = data.money.ToString();
    }

}
