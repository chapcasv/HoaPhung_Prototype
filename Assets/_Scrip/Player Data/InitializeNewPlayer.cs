﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

/// <summary>
/// Initialize data with default collection
/// </summary>

public class InitializeNewPlayer 
{   

    public static bool Try_Initialize(string playerName)
    {
        if (CanUse(playerName))
        {
            Initialize(playerName);
            return true;
        }
        else return false;
    }
    private static void Initialize(string playerName)
    {
        Player p = new Player();
        Set_dataNewPlayer(p, playerName);
        Save_System.SavePlayer(p);
    }

    private static void Set_dataNewPlayer(Player p, string player_name)
    {
        p.pName = player_name;

        p.level = 1;
        p.money = 9000;
        p.runeCoin = 100;
        p.playerAllCard = createCardDefault();
        p.playerAllDeck = new List<PlayerDeck>();
        p.playerAllDeck.Add(CreateDeckDefault(p.playerAllCard));
        p.playerAllDeck.Add(new PlayerDeck() { deckName = SystemString.deckNameDefault, cards = new List<PlayerCard>() });
        p.playerAllDeck.Add(new PlayerDeck() { deckName = SystemString.deckNameDefault, cards = new List<PlayerCard>() });
        p.maxDeckAmount = 3;
        p.deckDefault = 0;
    }

    private static List<PlayerCard> createCardDefault()
    {
        List<PlayerCard> playerAllCard = ConvertRandomCards(GetRandomListCard());
        return playerAllCard;
    }

    private static List<Card> GetRandomListCard()
    {
        List<Card> allCard = CardsData.ALLCard();
        List<Card> DeckDefault = new List<Card>();
        int count = 0; ///Test Only
        for (int i = 0; i < DecksData.maxCardInDeck; i++)
        {
            if (count == 3) count = 0;
            DeckDefault.Add(allCard[count]);
            count++;
        }
        return DeckDefault;
    }

    private static List<PlayerCard> ConvertRandomCards(List<Card> cardBeforeConvert)
    {
        List<PlayerCard> playerCards = new List<PlayerCard>();
        foreach (var card in cardBeforeConvert)
        {
            playerCards.Add(ConvertCard.CardToPlayerCard(card));
        }
            
        return playerCards;
    }

    private static PlayerDeck CreateDeckDefault(List<PlayerCard> cardDefault)
    {
        PlayerDeck playerDeck = new PlayerDeck();
        playerDeck.cards = new List<PlayerCard>();
        playerDeck.deckName = SystemString.deckNameDefault;

        foreach (PlayerCard card in cardDefault)
        {
            
            playerDeck.cards.Add(card);
        }

        return playerDeck;

    }

    protected static bool CanUse(string player_name)
    {
        if (player_name != null)
        {
            if (player_name.Length <= 12 && player_name.Length >= 4
                && !HaveSpace(player_name)
                && !HaveSpecialCharacter(player_name))
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    private static bool HaveSpecialCharacter(string player_name)
    {
        var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

        if (regexItem.IsMatch(player_name)) return true;
        else return false;
    }

    private static bool HaveSpace(string player_name)
    {
        if (player_name.Contains(" ")) return true;
        else return false;
    }
}
