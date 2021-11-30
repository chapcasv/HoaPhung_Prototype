using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decks 
{
    private string deckName;
    private List<Card> cards;

    public Decks(string deckName, List<Card> cards)
    {
        DeckName = deckName;
        Cards = cards;
    }

    public List<Card> Cards { get => cards; set => cards = value; }
    public string DeckName { get => deckName; set => deckName = value; }
}
