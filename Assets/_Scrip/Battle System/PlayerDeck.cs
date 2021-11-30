using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDeck
{
    public string deckName;
    public List<PlayerCard> cards;
    public int current_member;
    public int current_cost;
}
