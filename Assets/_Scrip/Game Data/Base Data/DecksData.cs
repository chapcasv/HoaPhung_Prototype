using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecksData 
{
    public static readonly int maxCardInDeck = 40;
    public static readonly int minCardInDeck = 35;

    private static List<Decks> allPlayerDeck = new List<Decks>();

    public static void LoadPlayerDeckToGame()
    {
        var playerdata = Save_System.LoadPlayer();
        foreach (var playerDeck in playerdata.playerDeck)
        {
            var listCard = Convert_CardInDeck_To_ListCard(playerDeck);
            Decks deck = new Decks(playerDeck.deckName, listCard);
            allPlayerDeck.Add(deck);
        }
    }

    public static Decks GetDefaultDeck()
    {
        Decks deckDefault = allPlayerDeck[GetIndex_DeckDefault()];
        return deckDefault;
    }

    private static int GetIndex_DeckDefault()
    {
        var playerData = Save_System.LoadPlayer();
        return playerData.deckDefaul;
    }

    public static Decks GetPlayerDeck(int deckIndex) { return allPlayerDeck[deckIndex];}

    public static List<Decks> GetAllDeck() { return allPlayerDeck; }

    private static List<Card> Convert_CardInDeck_To_ListCard(PlayerDeck playerdeck)
    {
        List<Card> cards = new List<Card>();
        foreach (var playerCard in playerdeck.cards)
        {
            cards.Add(ConvertCard.PlayerCardToCard(playerCard));
        }
        return cards;
    }
}

