using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Use
/// </summary>
[System.Serializable]
public class Player_Database 
{
    public string P_name;
    public int level;
    public int exp;
    public int runeCoin;
    public int money;
    public List<PlayerCard> playerCard;
    public List<PlayerDeck> playerDeck;
    public int deckDefaul;

    public Player_Database(Player player)
    {
        P_name = player.pName;
        level = player.level;
        runeCoin = player.runeCoin;
        money = player.money;
        playerCard = player.playerAllCard;
        playerDeck = player.playerAllDeck;
        deckDefaul = player.deckDefault;
    }
}
